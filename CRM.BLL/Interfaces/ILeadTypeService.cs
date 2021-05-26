using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface ILeadTypeService
    {
        Task<IEnumerable<LeadTypeDTO>> GetAllLeadType();
        Task<LeadTypeDTO> GetLeadTypeById(Guid id);
        Task<int> CreateLeadType(LeadTypeDTO leadTypeDTO);
        Task<int> UpdateLeadType(LeadTypeDTO leadTypeDTO);
        Task<int> UpdateFullLeadType(LeadTypeDTO leadTypeDTO);
        Task<int> DeleteLeadType(Guid Id);
    }
}
