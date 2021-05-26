using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public OpportunityService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OpportunityDTO>> GetAllOpportunity()
        {
            var opportunities = await db.Opportunities.ToListAsync();
            return _mapper.Map<IEnumerable<OpportunityDTO>>(opportunities);
        }
        public async Task<OpportunityDTO> GetOpportunityById(Guid id)
        {
            var opportunity = await db.Opportunities.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<OpportunityDTO>(opportunity);
        }
        public async Task<int> CreateOpportunity(OpportunityDTO opportunityDTO)
        {
            var opportunity = _mapper.Map<Opportunity>(opportunityDTO);
            await db.Opportunities.AddAsync(opportunity);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateOpportunity(OpportunityDTO opportunityDTO)
        {
            var opportunityMapper = _mapper.Map<Opportunity>(opportunityDTO);

            var opportunity = await db.Opportunities.FirstOrDefaultAsync(c => c.Id == opportunityMapper.Id);
            if (opportunity == null) throw new Exception("Opportunity not found");

            opportunity.DateStart = opportunityDTO.DateStart != null ? opportunityDTO.DateStart : opportunity.DateStart;
            opportunity.DateEnd = opportunityDTO.DateEnd != null ? opportunityDTO.DateEnd : opportunity.DateEnd;
            opportunity.TimeWait = opportunityDTO.TimeWait != null ? opportunityDTO.TimeWait : opportunity.TimeWait;
            opportunity.Description = opportunityDTO.Description != null ? opportunityDTO.Description : opportunity.Description;
            opportunity.Price = opportunityDTO.Price != 0 ? opportunityDTO.Price : 0;
            opportunity.Discount = opportunityDTO.Discount != 0 ? opportunityDTO.Discount : 0;
            opportunity.ContactId = opportunityDTO.ContactId != null ? opportunityDTO.ContactId : opportunity.ContactId;
            opportunity.CompanyId = opportunityDTO.CompanyId != null ? opportunityDTO.CompanyId : opportunity.CompanyId;
            opportunity.ResponsibleId = opportunityDTO.ResponsibleId != null ? opportunityDTO.ResponsibleId : opportunity.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullOpportunity(OpportunityDTO opportunityDTO)
        {
            var opportunityMapper = _mapper.Map<Opportunity>(opportunityDTO);

            var opportunity = await db.Opportunities.FirstOrDefaultAsync(c => c.Id == opportunityMapper.Id);
            if (opportunity == null) throw new Exception("Opportunity not found");

            opportunity.DateStart = opportunityDTO.DateStart;
            opportunity.DateEnd = opportunityDTO.DateEnd;
            opportunity.TimeWait = opportunityDTO.TimeWait;
            opportunity.Description = opportunityDTO.Description;
            opportunity.Price = opportunityDTO.Price;
            opportunity.Discount = opportunityDTO.Discount;
            opportunity.ContactId = opportunityDTO.ContactId;
            opportunity.CompanyId = opportunityDTO.CompanyId;
            opportunity.ResponsibleId = opportunityDTO.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteOpportunity(Guid Id)
        {
            var opportunity = await db.Opportunities.FirstOrDefaultAsync(c => c.Id == Id);
            if (opportunity == null) throw new Exception("Opportunity not found");

            db.Opportunities.Remove(opportunity);

            return await db.SaveChangesAsync();
        }

    }
}
