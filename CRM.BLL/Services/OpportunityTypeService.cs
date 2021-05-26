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
    public class OpportunityTypeService: IOpportunityTypeService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public OpportunityTypeService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OpportunityTypeDTO>> GetAllOpportunityType()
        {
            var opportunityTypes = await db.OpportunityTypes.ToListAsync();
            return _mapper.Map<IEnumerable<OpportunityTypeDTO>>(opportunityTypes);
        }
        public async Task<OpportunityTypeDTO> GetOpportunityTypeById(Guid id)
        {
            var opportunityType = await db.OpportunityTypes.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<OpportunityTypeDTO>(opportunityType);
        }
        public async Task<int> CreateOpportunityType(OpportunityTypeDTO opportunityTypeDTO)
        {
            var opportunityType = _mapper.Map<OpportunityType>(opportunityTypeDTO);
            await db.OpportunityTypes.AddAsync(opportunityType);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateOpportunityType(OpportunityTypeDTO opportunityTypeDTO)
        {
            var opportunityTypeMapper = _mapper.Map<OpportunityType>(opportunityTypeDTO);

            var opportunityType = await db.OpportunityTypes.FirstOrDefaultAsync(c => c.Id == opportunityTypeMapper.Id);
            if (opportunityType == null) throw new Exception("Opportunity type type not found");

            opportunityType.Name = opportunityTypeDTO.Name != null ? opportunityTypeDTO.Name : opportunityType.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullOpportunityType(OpportunityTypeDTO opportunityTypeDTO)
        {
            var opportunityTypeMapper = _mapper.Map<OpportunityType>(opportunityTypeDTO);

            var opportunityType = await db.OpportunityTypes.FirstOrDefaultAsync(c => c.Id == opportunityTypeMapper.Id);
            if (opportunityType == null) throw new Exception("Opportunity typepe not found");

            opportunityType.Name = opportunityTypeDTO.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteOpportunityType(Guid Id)
        {
            var opportunityType = await db.OpportunityTypes.FirstOrDefaultAsync(c => c.Id == Id);
            if (opportunityType == null) throw new Exception("Lead type not found");

            db.OpportunityTypes.Remove(opportunityType);

            return await db.SaveChangesAsync();
        }

    }
}
