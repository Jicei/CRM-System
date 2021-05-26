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
    public class LeadService: ILeadService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public LeadService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LeadDTO>> GetAllLead()
        {
            var leads = await db.Leads.ToListAsync();
            return _mapper.Map<IEnumerable<LeadDTO>>(leads);
        }
        public async Task<LeadDTO> GetLeadById(Guid id)
        {
            var lead = await db.Leads.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<LeadDTO>(lead);
        }
        public async Task<int> CreateLead(LeadDTO leadDTO)
        {
            var lead = _mapper.Map<Lead>(leadDTO);
            await db.Leads.AddAsync(lead);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateLead(LeadDTO leadDTO)
        {
            var leadMapper = _mapper.Map<Lead>(leadDTO);

            var lead = await db.Leads.FirstOrDefaultAsync(c => c.Id == leadMapper.Id);
            if (lead == null) throw new Exception("Lead not found");

            lead.Name = leadDTO.Name != null ? leadDTO.Name : lead.Name;
            lead.TypeId = leadDTO.TypeId != null ? leadDTO.TypeId : lead.TypeId;
            lead.TelephoneNumber = leadDTO.TelephoneNumber != null ? leadDTO.TelephoneNumber : lead.TelephoneNumber;
            lead.Email = leadDTO.Email != null ? leadDTO.Email : lead.Email;
            lead.Description = leadDTO.Description != null ? leadDTO.Description : lead.Description;
            lead.ActivityId = leadDTO.ActivityId != null ? leadDTO.ActivityId : lead.ActivityId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullLead(LeadDTO leadDTO)
        {
            var leadMapper = _mapper.Map<Lead>(leadDTO);

            var lead = await db.Leads.FirstOrDefaultAsync(c => c.Id == leadMapper.Id);
            if (lead == null) throw new Exception("Lead not found");

            lead.Name = leadDTO.Name;
            lead.TypeId = leadDTO.TypeId;
            lead.TelephoneNumber = leadDTO.TelephoneNumber;
            lead.Email = leadDTO.Email;
            lead.Description = leadDTO.Description;
            lead.ActivityId = leadDTO.ActivityId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteLead(Guid Id)
        {
            var lead = await db.Leads.FirstOrDefaultAsync(c => c.Id == Id);
            if (lead == null) throw new Exception("Lead not found");

            db.Leads.Remove(lead);

            return await db.SaveChangesAsync();
        }

    }
}
