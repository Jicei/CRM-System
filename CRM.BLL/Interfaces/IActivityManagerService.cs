using CRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IActivityManagerService
    {
        public Task<IEnumerable<ActivityManagerDTO>> GetAllActivityManager();
        public Task<ActivityManagerDTO> GetActivityManagerById(Guid id);
        public Task<int> CreateActivityManager(ActivityManagerDTO activityManagerDTO);
        public Task<int> UpdateActivityManager(ActivityManagerDTO activityManagerDTO);
        public Task<int> UpdateFullActivityManager(ActivityManagerDTO activityManagerDTO);
        public Task<int> DeleteActivityManager(Guid Id);
    }
}
