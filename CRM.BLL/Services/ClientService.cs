using AutoMapper;
using CRM.BLL.DTO;
using CRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.BLL.Services
{
    class ClientService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        Random z = new Random();
        public ClientService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public IEnumerable<ClientRFMAnalysisDTO> ContactRFMAnalysis(DateTime dateFrom, DateTime dateTo)
        {
            var opportunity = from c in db.Contacts
                              join o in db.Opportunities
                              on c.Id equals o.ContactId
                              where o.DateEnd >= dateFrom && o.DateEnd <= dateTo
                              select new
                              {
                                  ContactId = c.Id,
                                  CompanyId = o.CompanyId,
                                  IsFisicalClient = o.IsFisicalClient,
                                  DateEnd = o.DateEnd,
                                  Price = o.Price
                              };
            var clients = (from o in opportunity
                          where o.IsFisicalClient == false
                          group o by new { o.ContactId, o.IsFisicalClient } into phys
                          select new ClientRFMAnalysisDTO
                          {
                              ClientId = phys.Key.ContactId,
                              IsFisicalClient = phys.Key.IsFisicalClient,
                              Recency = phys.Max(o => o.DateEnd),
                              Frequency = phys.Count(),
                              MonetaryValue = phys.Sum(o => o.Price)
                          }).Union(
                                 from o in opportunity
                                 where o.IsFisicalClient == false
                                 group o by new { o.CompanyId, o.IsFisicalClient } into phys
                                 select new ClientRFMAnalysisDTO
                                 {
                                     ClientId = phys.Key.CompanyId,
                                     IsFisicalClient = phys.Key.IsFisicalClient,
                                     Recency = phys.Max(o => o.DateEnd),
                                     Frequency = phys.Count(),
                                     MonetaryValue = phys.Sum(o => o.Price)
                                 }).ToList();

            var recencyOneThird = clients.OrderByDescending(c => c.Recency).Take(clients.Count() / 3).Min(c => c.Recency);
            var recencyTwoThird = clients.OrderByDescending(c => c.Recency).Take((int)(clients.Count() * (2.0 / 3.0))).Min(c => c.Recency);

            var frequencyOneThird = clients.OrderByDescending(c => c.Frequency).Take(clients.Count() / 3).Min(c => c.Frequency);
            var frequencyTwoThird = clients.OrderByDescending(c => c.Frequency).Take((int)(clients.Count() * (2.0 / 3.0))).Min(c => c.Frequency);

            var monetaryValueOneThird = clients.OrderByDescending(c => c.MonetaryValue).Take(clients.Count() / 3).Min(c => c.MonetaryValue);
            var monetaryValueTwoThird = clients.OrderByDescending(c => c.MonetaryValue).Take((int)(clients.Count() * (2.0 / 3.0))).Min(c => c.MonetaryValue);

            foreach (var contact in clients)
            {
                if (contact.Recency <= recencyOneThird)
                {
                    contact.Class = "1";
                }
                else if (contact.Recency <= recencyTwoThird)
                {
                    contact.Class = "2";
                }
                else
                {
                    contact.Class = "3";
                }

                if (contact.Frequency <= frequencyOneThird)
                {
                    string.Concat(contact.Class, "1");
                }
                else if (contact.Frequency <= frequencyTwoThird)
                {
                    string.Concat(contact.Class, "2");
                }
                else
                {
                    string.Concat(contact.Class, "3");
                }

                if (contact.MonetaryValue <= monetaryValueOneThird)
                {
                    string.Concat(contact.Class, "1");
                }
                else if (contact.MonetaryValue <= monetaryValueTwoThird)
                {
                    string.Concat(contact.Class, "2");
                }
                else
                {
                    string.Concat(contact.Class, "3");
                }
            }

            return clients;

        }
        public Dictionary<int, KohonenaOpportunitySet> NeuronKohonena(DateTime dateFrom, DateTime dateTo)
        {
            var opportunity = from c in db.Contacts
                               join o in db.Opportunities
                               on c.Id equals o.ContactId
                               where o.DateEnd >= dateFrom && o.DateEnd <= dateTo
                               select new
                               {
                                   ContactId = c.Id,
                                   CompanyId = o.CompanyId,
                                   IsFisicalClient = o.IsFisicalClient,
                                   DateEnd = o.DateEnd,
                                   Price = o.Price
                               };
            var client = (from o in opportunity
                                 where o.IsFisicalClient == false
                                 group o by new { o.ContactId, o.IsFisicalClient } into phys
                                 select new KohonenaOpportunitySet
                                 {
                                     ClientId = phys.Key.ContactId,
                                     IsFisicalClient = phys.Key.IsFisicalClient,
                                     Recency = (int)(DateTime.Now - (phys.Max(o => o.DateEnd))).TotalSeconds,
                                     Frequency = phys.Count(),
                                     MonetaryValue = phys.Sum(o => o.Price)
                                 }).Union(
                                 from o in opportunity
                                 where o.IsFisicalClient == false
                                 group o by new { o.CompanyId, o.IsFisicalClient } into phys
                                 select new KohonenaOpportunitySet
                                 {
                                     ClientId = phys.Key.CompanyId,
                                     IsFisicalClient = phys.Key.IsFisicalClient,
                                     Recency = (int)(DateTime.Now - (phys.Max(o => o.DateEnd))).TotalSeconds,
                                     Frequency = phys.Count(),
                                     MonetaryValue = phys.Sum(o => o.Price)
                                 }).ToList();

            var maxRecency = client.Max(r => r.Recency);
            var minRecency = client.Min(r => r.Recency);

            var maxFrequency = client.Max(r => r.Frequency);
            var minFrequency = client.Min(r => r.Frequency);

            var maxMonetaryValue = client.Max(r => r.MonetaryValue);
            var minMonetaryValue = client.Min(r => r.MonetaryValue);

            var NormalisationValue = client.Select(o => new KohonenaOpportunitySet
            {
                ClientId = o.ClientId,
                Recency = (o.Recency - minRecency) / (maxRecency - minRecency),
                Frequency = (o.Frequency - minFrequency) / (maxFrequency - minFrequency),
                MonetaryValue = (o.MonetaryValue - minMonetaryValue) / (maxMonetaryValue - minMonetaryValue)
            });


            List<List<float>> weights;
            Dictionary<int, KohonenaOpportunitySet> clientInClass;
            var distance = new List<double>();

            int totalClass = 30;
            var classCount = 30;
            var speed = 0.1f;
            do
            {
                weights = GetWeigths(totalClass);
                totalClass = classCount;
                clientInClass = new Dictionary<int, KohonenaOpportunitySet>();
                foreach (var input in NormalisationValue)
                {
                    for (int i = 0; i < totalClass; i++)
                    {
                        var recency = Math.Pow(((double)input.Recency - (weights[i][0])), 2);
                        var frequency = Math.Pow((input.Frequency - weights[i][1]), 2);
                        var monetaryValue = Math.Pow((input.MonetaryValue - weights[i][2]), 2);

                        distance.Add(Math.Sqrt(recency + frequency + monetaryValue));
                    }

                    var minIndexValue = distance.IndexOf(distance.Min());

                    clientInClass.Add(minIndexValue, input);

                    weights[minIndexValue][0] += speed * ((float)input.Recency - weights[minIndexValue][0]);
                    weights[minIndexValue][1] += speed * ((float)input.Frequency - weights[minIndexValue][1]);
                    weights[minIndexValue][2] += speed * ((float)input.MonetaryValue - weights[minIndexValue][2]);
                }
                classCount = clientInClass.Select(c => c.Key).Distinct().Count();
            }
            while (classCount != totalClass);
            return clientInClass;

        }
        List<List<float>> GetWeigths(int n)
        {
            var weights = new List<List<float>>();

            var weightStart = 0.5 - 1.0 / Math.Sqrt(3.0);
            var weightEnd = 0.5 + 1.0 / Math.Sqrt(3.0);

            for (int i = 0; i < n; i++)
            {
                weights.Add(new List<float>());

                for (int j = 0; j < 3; j++)
                {
                    weights[i].Add(z.Next((int)(weightStart * 1000), (int)(weightEnd * 1000)) / 1000);
                }
            }
            return weights;
        }
    }
}
