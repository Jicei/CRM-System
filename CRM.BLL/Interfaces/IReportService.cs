using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CRM.BLL.Interfaces
{
    public interface IReportService
    {
        public Task<IEnumerable<TopManagerDTO>> TopEmployee(Guid EmployeeRoleId);

        public Task<IEnumerable<TopClientDTO>> TopClient();
        public Task<IEnumerable<PredictionDTO>> LinePrediction();
    }
}