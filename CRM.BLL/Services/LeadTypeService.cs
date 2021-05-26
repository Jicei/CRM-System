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
    public class LeadTypeService: ILeadTypeService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public LeadTypeService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LeadTypeDTO>> GetAllLeadType()
        {
            var leadTypes = await db.LeadTypes.ToListAsync();
            return _mapper.Map<IEnumerable<LeadTypeDTO>>(leadTypes);
        }
        public async Task<LeadTypeDTO> GetLeadTypeById(Guid id)
        {
            var leadTypes = await db.LeadTypes.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<LeadTypeDTO>(leadTypes);
        }
        public async Task<int> CreateLeadType(LeadTypeDTO leadTypeDTO)
        {
            var leadType = _mapper.Map<LeadType>(leadTypeDTO);
            await db.LeadTypes.AddAsync(leadType);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateLeadType(LeadTypeDTO leadTypeDTO)
        {
            var leadTypeMapper = _mapper.Map<LeadType>(leadTypeDTO);

            var leadType = await db.LeadTypes.FirstOrDefaultAsync(c => c.Id == leadTypeMapper.Id);
            if (leadType == null) throw new Exception("Lead type not found");

            leadType.Name = leadTypeDTO.Name != null ? leadTypeDTO.Name : leadType.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullLeadType(LeadTypeDTO leadTypeDTO)
        {
            var leadTypeMapper = _mapper.Map<Lead>(leadTypeDTO);

            var leadType = await db.LeadTypes.FirstOrDefaultAsync(c => c.Id == leadTypeMapper.Id);
            if (leadType == null) throw new Exception("Lead type not found");

            leadType.Name = leadTypeDTO.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteLeadType(Guid Id)
        {
            var leadType = await db.LeadTypes.FirstOrDefaultAsync(c => c.Id == Id);
            if (leadType == null) throw new Exception("Lead type not found");

            db.LeadTypes.Remove(leadType);

            return await db.SaveChangesAsync();
        }

    }
}
