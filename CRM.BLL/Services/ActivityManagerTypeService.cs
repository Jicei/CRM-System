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
    public class ActivityManagerTypeService : IActivityManagerTypeService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ActivityManagerTypeService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ActivityManagerTypeDTO>> GetAllActivityManagerType()
        {
            var activityManagerType = await db.ActivityManagerTypes.ToListAsync();
            return _mapper.Map<IEnumerable<ActivityManagerTypeDTO>>(activityManagerType);
        }
        public async Task<ActivityManagerTypeDTO> GetActivityManagerTypeById(Guid id)
        {
            var activityManagerType = await db.ActivityManagerTypes.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<ActivityManagerTypeDTO>(activityManagerType);
        }
        public async Task<int> CreateActivityManagerType(ActivityManagerTypeDTO activityManagerTypeDTO)
        {
            var activityManagerType = _mapper.Map<ActivityManagerType>(activityManagerTypeDTO);
            await db.ActivityManagerTypes.AddAsync(activityManagerType);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateActivityManagerType(ActivityManagerTypeDTO activityManagerTypeDTO)
        {
            var activityManagerMapper = _mapper.Map<ActivityManagerType>(activityManagerTypeDTO);

            var activityManagerType = await db.ActivityManagerTypes.FirstOrDefaultAsync(a => a.Id == activityManagerMapper.Id);
            if (activityManagerType == null) throw new Exception("Type ActivityManager not found");

            activityManagerType.Name = activityManagerTypeDTO.Name != null ? activityManagerTypeDTO.Name : activityManagerType.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullActivityManagerType(ActivityManagerTypeDTO activityManagerTypeDTO)
        {
            var activityManagerTypeMapper = _mapper.Map<ActivityManagerType>(activityManagerTypeDTO);

            var activityManagerType = await db.ActivityManagerTypes.FirstOrDefaultAsync(c => c.Id == activityManagerTypeMapper.Id);
            if (activityManagerType == null) throw new Exception("Type ActivityManager not found");

            activityManagerType.Name = activityManagerTypeDTO.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteActivityManagerType(Guid Id)
        {
            var activityManagerType = await db.ActivityManagerTypes.FirstOrDefaultAsync(c => c.Id == Id);
            if (activityManagerType == null) throw new Exception("Type ActivityManager not found");

            db.ActivityManagerTypes.Remove(activityManagerType);

            return await db.SaveChangesAsync();
        }
    }
}
