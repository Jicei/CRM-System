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
    public class ActivityService : IActivityService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ActivityService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ActivityDTO>> GetAllActivity()
        {
            var activity = await db.Activities.ToListAsync();
            return _mapper.Map<IEnumerable<ActivityDTO>>(activity);
        }
        public async Task<ActivityDTO> GetActivityById(Guid id)
        {
            var activity = await db.Activities.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<ActivityDTO>(activity);
        }
        public async Task<int> CreateActivity(ActivityDTO activityDTO)
        {
            var activity = _mapper.Map<Activity>(activityDTO);
            await db.Activities.AddAsync(activity);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateActivity(ActivityDTO activityDTO)
        {
            var activityMapper = _mapper.Map<Activity>(activityDTO);

            var activity = await db.Activities.FirstOrDefaultAsync(c => c.Id == activityMapper.Id);
            if (activity == null) throw new Exception("Activity not found");

            activity.CreatedOn = activityDTO.CreatedOn != null ? activityDTO.CreatedOn : activity.CreatedOn;
            activity.Name = activityDTO.Name != null ? activityDTO.Name : activity.Name;
            activity.DateStart = activityDTO.DateStart != null ? activityDTO.DateStart : activity.DateStart;
            activity.DateEnd = activityDTO.DateEnd != null ? activityDTO.DateEnd : activity.DateEnd;
            activity.TypeActivityId = activityDTO.TypeActivityId != null ? activityDTO.TypeActivityId : activity.TypeActivityId;
            activity.ResponsibleId = activityDTO.ResponsibleId != null ? activityDTO.ResponsibleId : activity.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullActivity(ActivityDTO activityDTO)
        {
            var activityMapper = _mapper.Map<Activity>(activityDTO);

            var activity = await db.Activities.FirstOrDefaultAsync(c => c.Id == activityMapper.Id);
            if (activity == null) throw new Exception("Activity not found");

            activity.CreatedOn = activityDTO.CreatedOn;
            activity.Name = activityDTO.Name;
            activity.DateStart = activityDTO.DateStart;
            activity.DateEnd = activityDTO.DateEnd;
            activity.TypeActivityId = activityDTO.TypeActivityId;
            activity.ResponsibleId = activityDTO.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteActivity(Guid Id)
        {
            var activity = await db.Activities.FirstOrDefaultAsync(c => c.Id == Id);
            if (activity == null) throw new Exception("Activity not found");

            db.Activities.Remove(activity);

            return await db.SaveChangesAsync();
        }
    }
}
