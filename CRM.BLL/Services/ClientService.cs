using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.BLL.Services
{
    public class ClientService: IClientService
    {
        private readonly CrmDbContext db;
        Random z = new Random();
        public ClientService(CrmDbContext _crmDbContext)
        {
            db = _crmDbContext;
        }
        public IEnumerable<ClientRFMAnalysisDTO> ContactRFMAnalysis(/*DateTime dateFrom, DateTime dateTo*/)
        {
            var opportunity = from c in db.Contacts
                              join o in db.Opportunities
                              on c.Id equals o.ContactId
                              //where o.DateEnd >= dateFrom && o.DateEnd <= dateTo
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
                                 where o.IsFisicalClient == true
                                 group o by new { o.CompanyId, o.IsFisicalClient } into u
                                 select new ClientRFMAnalysisDTO
                                 {
                                     ClientId = u.Key.CompanyId,
                                     IsFisicalClient = u.Key.IsFisicalClient,
                                     Recency = u.Max(o => o.DateEnd),
                                     Frequency = u.Count(),
                                     MonetaryValue = u.Sum(o => o.Price)
                                 }).ToList();
            if (clients.Count() == 0)
            {
                throw new Exception("Client is empty");
            }
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
                    contact.Class = string.Concat(contact.Class, "1");
                }
                else if (contact.Frequency <= frequencyTwoThird)
                {
                    contact.Class = string.Concat(contact.Class, "2");
                }
                else
                {
                    contact.Class = string.Concat(contact.Class, "3");
                }

                if (contact.MonetaryValue <= monetaryValueOneThird)
                {
                    contact.Class = string.Concat(contact.Class, "1");
                }
                else if (contact.MonetaryValue <= monetaryValueTwoThird)
                {
                    contact.Class = string.Concat(contact.Class, "2");
                }
                else
                {
                    contact.Class = string.Concat(contact.Class, "3");
                }
            }

            return clients;

        }
        public List<KohonenaDTO> NeuronKohonena(/*DateTime dateFrom, DateTime dateTo*/)
        {
            var opportunity = (from c in db.Contacts
                               join o in db.Opportunities
                               on c.Id equals o.ContactId
                               //where o.DateEnd >= dateFrom && o.DateEnd <= dateTo
                               select new
                               {
                                   ContactId = c.Id,
                                   CompanyId = o.CompanyId,
                                   IsFisicalClient = o.IsFisicalClient,
                                   DateEnd = o.DateEnd,
                                   Price = o.Price
                               }).ToList();
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
                                 where o.IsFisicalClient == true
                                 group o by new { o.CompanyId, o.IsFisicalClient } into u
                                 select new KohonenaOpportunitySet
                                 {
                                     ClientId = u.Key.CompanyId,
                                     IsFisicalClient = u.Key.IsFisicalClient,
                                     Recency = (int)(DateTime.Now - (u.Max(o => o.DateEnd))).TotalSeconds,
                                     Frequency = u.Count(),
                                     MonetaryValue = u.Sum(o => o.Price)
                                 }).ToList();
            if(client.Count() == 0)
            {
                throw new Exception("Client is empty");
            }
            var maxRecency = client.Max(r => r.Recency);
            var minRecency = client.Min(r => r.Recency);

            var maxFrequency = client.Max(r => r.Frequency);
            var minFrequency = client.Min(r => r.Frequency);

            var maxMonetaryValue = client.Max(r => r.MonetaryValue);
            var minMonetaryValue = client.Min(r => r.MonetaryValue);

            var NormalisationValue = client.Select(o => new KohonenaOpportunitySet
            {
                ClientId = o.ClientId,
                Recency = (o.Recency - minRecency) / (maxRecency - minRecency != 0 ? maxRecency - minRecency : 1),
                Frequency = (o.Frequency - minFrequency) / (maxFrequency - minFrequency != 0 ? maxFrequency - minFrequency : 1),
                MonetaryValue = (o.MonetaryValue - minMonetaryValue) / (maxMonetaryValue - minMonetaryValue != 0 ? maxMonetaryValue - minMonetaryValue : 1)
            });


            List<List<double>> weights;
            List<KohonenaDTO> clientInClass;
            double[] distance;

            int totalClass = 30;
            var classCount = 30;
            var speed = 0.1f;
            do
            {
                weights = GetWeigths(totalClass);
                totalClass = classCount;
                clientInClass = new List<KohonenaDTO>();
                distance = new double[totalClass];
                foreach (var input in NormalisationValue)
                {
                    for (int i = 0; i < totalClass; i++)
                    {
                        var recency = Math.Pow(((double)input.Recency - (weights[i][0])), 2);
                        var frequency = Math.Pow((input.Frequency - weights[i][1]), 2);
                        var monetaryValue = Math.Pow((input.MonetaryValue - weights[i][2]), 2);

                        distance[i] = (Math.Sqrt(recency + frequency + monetaryValue));
                    }

                    var minIndexValue = Array.IndexOf(distance, distance.Min());

                    clientInClass.Add( new KohonenaDTO 
                    { 
                        Class = minIndexValue,
                        Client = input
                    });

                    weights[minIndexValue][0] += speed * ((float)input.Recency - weights[minIndexValue][0]);
                    weights[minIndexValue][1] += speed * ((float)input.Frequency - weights[minIndexValue][1]);
                    weights[minIndexValue][2] += speed * ((float)input.MonetaryValue - weights[minIndexValue][2]);
                }
                classCount = clientInClass.Select(c => c.Class).Distinct().Count();
            }
            while (30 == totalClass);
            return clientInClass;

        }
        List<List<double>> GetWeigths(int n)
        {
            var weights = new List<List<double>>();

            var weightStart = 0.5 - 1.0 / Math.Sqrt(3.0);
            var weightEnd = 0.5 + 1.0 / Math.Sqrt(3.0);

            for (int i = 0; i < n; i++)
            {
                weights.Add(new List<double>());

                for (int j = 0; j < 3; j++)
                {
                    weights[i].Add(z.NextDouble());
                }
            }
            return weights;
        }
    }
}
