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
                Amount = opportunities[countOpp - 1].Amount + sumAmount / countOpp,
                Year = year,
                Month = month
            });
            return opportunities;
        }
    }
}
