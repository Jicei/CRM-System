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
    public class ActivityManagerService : IActivityManagerService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ActivityManagerService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ActivityManagerDTO>> GetAllActivityManager()
        {
            var activityManager = await db.ActivityManagers.ToListAsync();
            return _mapper.Map<IEnumerable<ActivityManagerDTO>>(activityManager);
        }
        public async Task<ActivityManagerDTO> GetActivityManagerById(Guid id)
        {
            var activityManager = await db.ActivityManagers.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<ActivityManagerDTO>(activityManager);
        }
        public async Task<int> CreateActivityManager(ActivityManagerDTO activityManagerDTO)
        {
            var activityManager = _mapper.Map<ActivityManager>(activityManagerDTO);
            await db.ActivityManagers.AddAsync(activityManager);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateActivityManager(ActivityManagerDTO activityManagerDTO)
        {
            var activityManagerMapper = _mapper.Map<ActivityManager>(activityManagerDTO);

            var activityManager = await db.ActivityManagers.FirstOrDefaultAsync(a => a.Id == activityManagerMapper.Id);
            if (activityManager == null) throw new Exception("Activity not found");

            activityManager.Name = activityManagerDTO.Name != null ? activityManagerDTO.Name : activityManager.Name;
            activityManager.ActivityManagerTypeId = activityManagerDTO.ActivityManagerTypeId != null ? activityManagerDTO.ActivityManagerTypeId : activityManager.ActivityManagerTypeId;
            activityManager.Description = activityManagerDTO.Description != null ? activityManagerDTO.Description : activityManager.Description;
            activityManager.ContactId = activityManagerDTO.ContactId != null ? activityManagerDTO.ContactId : activityManager.ContactId;
            activityManager.LeadId = activityManagerDTO.LeadId != null ? activityManagerDTO.LeadId : activityManager.LeadId;
            activityManager.ResponsibleId = activityManagerDTO.ResponsibleId != null ? activityManagerDTO.ResponsibleId : activityManager.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullActivityManager(ActivityManagerDTO activityManagerDTO)
        {
            var activityManagerMapper = _mapper.Map<ActivityManager>(activityManagerDTO);

            var activityManager = await db.ActivityManagers.FirstOrDefaultAsync(c => c.Id == activityManagerMapper.Id);
            if (activityManager == null) throw new Exception("Activity not found");

            activityManager.Name = activityManagerDTO.Name;
            activityManager.ActivityManagerTypeId = activityManagerDTO.ActivityManagerTypeId;
            activityManager.Description = activityManagerDTO.Description;
            activityManager.ContactId = activityManagerDTO.ContactId;
            activityManager.LeadId = activityManagerDTO.LeadId;
            activityManager.ResponsibleId = activityManagerDTO.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteActivityManager(Guid Id)
        {
            var activityManagers = await db.ActivityManagers.FirstOrDefaultAsync(c => c.Id == Id);
            if (activityManagers == null) throw new Exception("Activity not found");

            db.ActivityManagers.Remove(activityManagers);

            return await db.SaveChangesAsync();
        }
    }
}
