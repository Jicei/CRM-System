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
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ActivityTypeService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ActivityTypeDTO>> GetAllActivityType()
        {
            var activityType = await db.ActivityTypes.ToListAsync();
            return _mapper.Map<IEnumerable<ActivityTypeDTO>>(activityType);
        }
        public async Task<ActivityTypeDTO> GetActivityTypeById(Guid id)
        {
            var activityType = await db.ActivityTypes.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<ActivityTypeDTO>(activityType);
        }
        public async Task<int> CreateActivityType(ActivityTypeDTO activityTypeDTO)
        {
            var activityType = _mapper.Map<ActivityType>(activityTypeDTO);
            await db.ActivityTypes.AddAsync(activityType);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateActivityType(ActivityTypeDTO activityTypeDTO)
        {
            var activityTypeMapper = _mapper.Map<ActivityType>(activityTypeDTO);

            var activityType = await db.ActivityTypes.FirstOrDefaultAsync(c => c.Id == activityTypeMapper.Id);
            if (activityType == null) throw new Exception("Activity Type not found");

            activityType.Name = activityTypeDTO.Name != null ? activityTypeDTO.Name : activityType.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullActivityType(ActivityTypeDTO activityTypeDTO)
        {
            var activityTypeMapper = _mapper.Map<ActivityType>(activityTypeDTO);

            var activityType = await db.ActivityTypes.FirstOrDefaultAsync(c => c.Id == activityTypeMapper.Id);
            if (activityType == null) throw new Exception("Activity type not found");

            activityType.Name = activityTypeDTO.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteActivityType(Guid Id)
        {
            var activityType = await db.ActivityTypes.FirstOrDefaultAsync(c => c.Id == Id);
            if (activityType == null) throw new Exception("Activity type not found");

            db.ActivityTypes.Remove(activityType);

            return await db.SaveChangesAsync();
        }
    }
}
