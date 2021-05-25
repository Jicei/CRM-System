using CRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IActivityManagerTypeService
    {
        Task<IEnumerable<ActivityManagerTypeDTO>> GetAllActivityManagerType();
        Task<ActivityManagerTypeDTO> GetActivityManagerTypeById(Guid id);
        Task<int> CreateActivityManagerType(ActivityManagerTypeDTO activityManagerTypeDTO);
        Task<int> UpdateActivityManagerType(ActivityManagerTypeDTO activityManagerTypeDTO);
        Task<int> UpdateFullActivityManagerType(ActivityManagerTypeDTO activityManagerTypeDTO);
        Task<int> DeleteActivityManagerType(Guid Id);
    }
}