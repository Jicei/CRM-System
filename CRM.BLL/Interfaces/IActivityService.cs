using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTO>> GetAllActivity();

        Task<ActivityDTO> GetActivityById(Guid id);

        public Task<int> CreateActivity(ActivityDTO activityDTO);

        public Task<int> UpdateActivity(ActivityDTO activityDTO);

        public Task<int> UpdateFullActivity(ActivityDTO activityDTO);
        public Task<int> DeleteActivity(Guid id);
    }
}
