using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly CrmDbContext db;
        public ReportService(CrmDbContext _crmDbContext)
        {
            db = _crmDbContext;
        }

        public async Task<IEnumerable<TopManagerDTO>> TopEmployee(Guid EmployeeRoleId)
        {
            return await (from m in db.Employees
                           join mr in db.EmployeeInRoles
                           on m.Id equals mr.EmployeeId
                           where mr.EmployeeId == EmployeeRoleId
                           join o in db.Opportunities
                           on m.Id equals o.ResponsibleId
                           group o by new { m.Id, m.Name, m.SurName, m.Patronymic}  into groupResponsible
                           orderby groupResponsible.Sum(o => o.Price) descending
                           select new TopManagerDTO
                           {
                               Id = groupResponsible.Key.Id,
                               Name = groupResponsible.Key.Name,
                               SurName = groupResponsible.Key.SurName,
                               Patronymic = groupResponsible.Key.Patronymic,
                               Sum = groupResponsible.Sum(o => o.Price)
                           }).ToListAsync();
        }

        public async Task<IEnumerable<TopClientDTO>> TopClient()
        {
            return await (from o in db.Opportunities
                          where o.IsFisicalClient == true
                          group o by o.CompanyId into clientGroup
                          select new TopClientDTO
                          {
                              ClientId = clientGroup.Key,
                              Price = clientGroup.Sum(o => o.Price)
                          }).Union
                          (from o in db.Opportunities
                           where o.IsFisicalClient == false
                           group o by o.ContactId into clientGroup
                           select new TopClientDTO
                           {
                               ClientId = clientGroup.Key,
                               Price = clientGroup.Sum(o => o.Price)
                           }).OrderByDescending(o => o.Price).ToListAsync();
        }
        public async Task<IEnumerable<PredictionDTO>> LinePrediction()
        {
             var opportunities = await (from o in db.Opportunities
                                group o by new { o.DateEnd.Year, o.DateEnd.Month } into oppGroup
                                orderby oppGroup.Key.Year, oppGroup.Key.Month
                                select new PredictionDTO
                                {
                                    Amount = oppGroup.Sum(o=> o.Price),
                                    Year = oppGroup.Key.Year,
                                    Month = oppGroup.Key.Month
                                }).ToListAsync();
            var countOpp = opportunities.Count();
            float sumAmount = 0;
            for(int i = 1; i < countOpp; i++) {
                sumAmount += opportunities[i].Amount - opportunities[i - 1].Amount;
            }
            int year = opportunities[countOpp - 1].Year;
            int month;
            if(opportunities[countOpp - 1].Month == 12)
            {
                month = 1;
                year += 1;
            }
            else
            {
                month = opportunities[countOpp - 1].Month + 1;
            }
            opportunities.Add(new PredictionDTO
            {
                Amount = opportunities[countOpp - 1].Amount + (sumAmount / (countOpp-1)),
                Year = year,
                Month = month
            });
            return opportunities;
        }
        public async Task<IEnumerable<PredictionDTO>> AveragePrediction()
        {
            var opportunities = await (from o in db.Opportunities
                                       group o by new { o.DateEnd.Year, o.DateEnd.Month } into oppGroup
                                       orderby oppGroup.Key.Year, oppGroup.Key.Month
                                       select new PredictionDTO
                                       {
                                           Amount = oppGroup.Sum(o => o.Price),
                                           Year = oppGroup.Key.Year,
                                           Month = oppGroup.Key.Month
                                       }).ToListAsync();
            var oppotyunityByKvartal = new List<SeasonalityQuarter>();
            var years = from o in opportunities
                        group o by o.Year into groupYear
                        select groupYear.Key;
            foreach(var year in years)
            {
                oppotyunityByKvartal.Add(new SeasonalityQuarter { Year = year, Quarter = 1, Amount = opportunities.Where(o => (o.Year == year) && (o.Month == 1 || o.Month == 2 || o.Month == 3)).Sum(o => o.Amount) });
                oppotyunityByKvartal.Add(new SeasonalityQuarter { Year = year, Quarter = 2, Amount = opportunities.Where(o => (o.Year == year) && (o.Month == 4 || o.Month == 5 || o.Month == 6)).Sum(o => o.Amount) });
                oppotyunityByKvartal.Add(new SeasonalityQuarter { Year = year, Quarter = 3, Amount = opportunities.Where(o => (o.Year == year) && (o.Month == 7 || o.Month == 8 || o.Month == 9)).Sum(o => o.Amount) });
                oppotyunityByKvartal.Add(new SeasonalityQuarter { Year = year, Quarter = 4, Amount = opportunities.Where(o => (o.Year == year) && (o.Month == 10 || o.Month == 11 || o.Month == 12)).Sum(o => o.Amount) });
            }
            var oppotyunityByKvartalOrderByYearMonth = oppotyunityByKvartal.OrderBy(o=> o.Year).ThenBy(o=> o.Quarter).ToList();
            for(int i = 1; i < oppotyunityByKvartalOrderByYearMonth.Count()-2; i++)
            {
                oppotyunityByKvartalOrderByYearMonth[i].Average = (1f / 4f) * (oppotyunityByKvartalOrderByYearMonth[i - 1].Amount + oppotyunityByKvartalOrderByYearMonth[i].Amount + oppotyunityByKvartalOrderByYearMonth[i + 1].Amount + oppotyunityByKvartalOrderByYearMonth[i + 2].Amount);
            }
            for (int i = 2; i < oppotyunityByKvartalOrderByYearMonth.Count() - 2; i++)
            {
                oppotyunityByKvartalOrderByYearMonth[i].CentralizeAverage = (1f / 2f) * (oppotyunityByKvartalOrderByYearMonth[i - 1].Average + oppotyunityByKvartalOrderByYearMonth[i].Average);
                oppotyunityByKvartalOrderByYearMonth[i].SeasonalityIndex = oppotyunityByKvartalOrderByYearMonth[i].Amount / oppotyunityByKvartalOrderByYearMonth[i].CentralizeAverage;
            }
            //var seasonalityIndex = new List<SeasonalityIndex>();
            var seasonalityIndex = new List<SeasonalityIndex>()
                    {
                        new SeasonalityIndex
                        {
                            Index = (oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 1).Average(o => o.SeasonalityIndex) != 0 ? oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 1).Average(o => o.SeasonalityIndex) : 1),
                            Quarter = 1
                        },
                        new SeasonalityIndex
                        {
                            Index = (oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 2).Average(o => o.SeasonalityIndex) != 0 ? oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 2).Average(o => o.SeasonalityIndex) : 1),
                            Quarter = 2
                        },
                        new SeasonalityIndex
                        {
                            Index = (oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 3).Average(o => o.SeasonalityIndex) != 0 ? oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 3).Average(o => o.SeasonalityIndex) : 1),
                            Quarter = 3
                        },
                        new SeasonalityIndex
                        {
                            Index = (oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 4).Average(o => o.SeasonalityIndex) != 0 ? oppotyunityByKvartalOrderByYearMonth.Where(o => o.Quarter == 4).Average(o => o.SeasonalityIndex) : 1),
                            Quarter = 4
                        }
                    };
            var delta = (1f / 3f) * (opportunities[opportunities.Count() - 1].Amount - opportunities[opportunities.Count() - 2].Amount);
            var slidingAverage = (1f / 3f) * (opportunities[opportunities.Count() - 1].Amount + opportunities[opportunities.Count() - 2].Amount + opportunities[opportunities.Count() - 3].Amount);
            var prediction = slidingAverage + delta;
            var countOpp = opportunities.Count();
            int yearPred = opportunities[countOpp - 1].Year;
            int month;
            int quarter;
            if (opportunities[countOpp - 1].Month == 12)
            {
                quarter = 1;
                month = 1;
                yearPred += 1;
            }
            else
            {
                month = opportunities[countOpp - 1].Month + 1;
                quarter = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(month) / 3));
            }
            prediction = prediction * (seasonalityIndex.FirstOrDefault(s=> s.Quarter == quarter).Index > 1? 1: seasonalityIndex.FirstOrDefault(s => s.Quarter == quarter).Index);
            opportunities.Add(new PredictionDTO
            {
                Amount = prediction,
                Year = yearPred,
                Month = month
            });
            return opportunities;
        }
        public async Task<IEnumerable<PredictionDTO>> LineMNK() 
        {
            var opportunities = await (from o in db.Opportunities
                                       group o by new { o.DateEnd.Year, o.DateEnd.Month } into oppGroup
                                       orderby oppGroup.Key.Year, oppGroup.Key.Month
                                       select new PredictionDTO
                                       {
                                           Amount = oppGroup.Sum(o => o.Price),
                                           Year = oppGroup.Key.Year,
                                           Month = oppGroup.Key.Month
                                       }).ToListAsync();
            int []x = Enumerable.Range(1, opportunities.Count()).ToArray();
            var y = new List<float>();
            foreach (var opp in opportunities)
            {
                y.Add(opp.Amount);
            }
            var sumX = x.Sum(x=> x);
            var sumY = y.Sum(y=> y);
            float sumXY = 0;
            for(int i = 0; i < opportunities.Count(); i++)
            {
                sumXY += x[i] * y[i];
            }
            var sumXX = x.Sum(x => x * x);
            var sumYY = y.Sum(y => y * y);

            var a = ((sumX * sumY) - (opportunities.Count() * sumXY)) / ((sumX * sumX) - (opportunities.Count * sumXX));
            var b = ((sumX * sumXY) - (sumXX * sumY)) / ((sumX * sumX) - (opportunities.Count() * sumXX));
            var prediction = a*(opportunities.Count + 1) + b;

            int year = opportunities[opportunities.Count() - 1].Year;
            int month;
            if (opportunities[opportunities.Count() - 1].Month == 12)
            {
                month = 1;
                year += 1;
            }
            else
            {
                month = opportunities[opportunities.Count() - 1].Month + 1;
            }
            opportunities.Add(new PredictionDTO
            {
                Amount = prediction,
                Year = year,
                Month = month
            });
            return opportunities;
        }
        public async Task<IEnumerable<PredictionDTO>> IndicativeMNK()
        {
            var opportunities = await (from o in db.Opportunities
                                       group o by new { o.DateEnd.Year, o.DateEnd.Month } into oppGroup
                                       orderby oppGroup.Key.Year, oppGroup.Key.Month
                                       select new PredictionDTO
                                       {
                                           Amount = oppGroup.Sum(o => o.Price),
                                           Year = oppGroup.Key.Year,
                                           Month = oppGroup.Key.Month
                                       }).ToListAsync();
            int[] x = Enumerable.Range(1, opportunities.Count()).ToArray();
            var y = new List<float>();
            foreach (var opp in opportunities)
            {
                y.Add(opp.Amount);
            }
            var sumX = x.Sum(x => x);
            var sumY = y.Sum(y => y);
            var sumXX = x.Sum(x=> x*x);
            var sumLnY = y.Sum(y => Math.Log(y));
            double sumXLnY = 0;
            for(int i = 0; i < opportunities.Count(); i++)
            {
                sumXLnY += x[i] * Math.Log(y[i]);
            }
            var b = Math.Exp(((opportunities.Count() * sumXLnY) - (sumX*sumLnY)) / ((opportunities.Count() * sumXX) - (sumX*sumX)));
            var a = Math.Exp(((1f / opportunities.Count) * sumLnY) - ((Math.Log(b) / opportunities.Count()) * sumX));

            var prediction = a * Math.Pow(b, opportunities.Count() + 1);

            int year = opportunities[opportunities.Count() - 1].Year;
            int month;
            if (opportunities[opportunities.Count() - 1].Month == 12)
            {
                month = 1;
                year += 1;
            }
            else
            {
                month = opportunities[opportunities.Count() - 1].Month + 1;
            }
            opportunities.Add(new PredictionDTO
            {
                Amount = (float)prediction,
                Year = year,
                Month = month
            });
            return opportunities;
        }
    }
}
