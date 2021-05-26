using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IOpportunityTypeService
    {
        Task<IEnumerable<OpportunityTypeDTO>> GetAllOpportunityType();
        Task<OpportunityTypeDTO> GetOpportunityTypeById(Guid id);
        Task<int> CreateOpportunityType(OpportunityTypeDTO opportunityTypeDTO);
        Task<int> UpdateOpportunityType(OpportunityTypeDTO opportunityTypeDTO);
        Task<int> UpdateFullOpportunityType(OpportunityTypeDTO opportunityTypeDTO);
        Task<int> DeleteOpportunityType(Guid Id);
    }
}
