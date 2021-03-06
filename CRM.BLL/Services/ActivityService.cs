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
        public IEnumerable<ActivityABCXYZAnalysisDTO> ActivityABCXYZanalysis(/*DateTime dateFrom, DateTime dateTo*/)
        {
            var leadCount = db.Leads/*.Where(l => l.CreatedOn >= dateFrom && l.CreatedOn <= dateTo)*/.Count();
            var leadCountGroupByActivity = (from l in db.Leads
                                           join a in db.Activities
                                           on l.ActivityId equals a.Id  
                                          // where l.CreatedOn >= dateFrom && l.CreatedOn <= dateTo
                                           group a by new { a.Id, a.Name } into leadActivityGroup
                                           orderby leadActivityGroup.Count() descending
                                           select new ActivityABCXYZAnalysisDTO
                                           {
                                               Id = leadActivityGroup.Key.Id,
                                               Name = leadActivityGroup.Key.Name,
                                               Count = leadActivityGroup.Count(),
                                           }).ToList();

            var leadCountGroupByActivityAverage = leadCountGroupByActivity.Average(l => l.Count);

            var sigma = Math.Sqrt(leadCountGroupByActivity.Sum(l => Math.Pow((l.Count - leadCountGroupByActivityAverage), 2)) / leadCountGroupByActivity.Count());
            float leadPartQuantity = 0;
            double coefficientVariation = 0;

            foreach (var lead in leadCountGroupByActivity)
            {
                if (leadPartQuantity <= 0.8)
                {
                    lead.Category = "A";
                }
                else if (leadPartQuantity <= 0.95)
                {
                    lead.Category = "B";
                }
                else
                {
                    lead.Category = "C";
                }
                lead.PartCount = (float)lead.Count / leadCount;
                leadPartQuantity += lead.PartCount;

                coefficientVariation = sigma / lead.Count;

                if (coefficientVariation <= 0.1)
                {
                    lead.Category = string.Concat(lead.Category, "X");
                }
                else if (coefficientVariation <= 0.25)
                {
                    lead.Category = string.Concat(lead.Category, "Y");
                }
                else
                {
                    lead.Category = string.Concat(lead.Category, "Z");
                }
            }

            return leadCountGroupByActivity;
        }
    }
}
