using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadDTO>> GetAllLead();
        Task<LeadDTO> GetLeadById(Guid id);
        Task<int> CreateLead(LeadDTO employeeDTO);
        Task<int> UpdateLead(LeadDTO employeeDTO);
        Task<int> UpdateFullLead(LeadDTO employeeDTO);
        Task<int> DeleteLead(Guid Id);
    }
}
