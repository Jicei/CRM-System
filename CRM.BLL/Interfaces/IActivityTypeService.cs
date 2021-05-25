using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IActivityTypeService
    {
        Task<IEnumerable<ActivityTypeDTO>> GetAllActivityType();

        Task<ActivityTypeDTO> GetActivityTypeById(Guid id);

        public Task<int> CreateActivityType(ActivityTypeDTO activityTypeDTO);

        public Task<int> UpdateActivityType(ActivityTypeDTO activityTypeDTO);

        public Task<int> UpdateFullActivityType(ActivityTypeDTO activityTypeDTO);
        public Task<int> DeleteActivityType(Guid id);
    }
}
