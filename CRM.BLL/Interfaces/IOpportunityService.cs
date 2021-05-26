using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IOpportunityService
    {
        Task<IEnumerable<OpportunityDTO>> GetAllOpportunity();
        Task<OpportunityDTO> GetOpportunityById(Guid id);
        Task<int> CreateOpportunity(OpportunityDTO opportunityDTO);
        Task<int> UpdateOpportunity(OpportunityDTO opportunityDTO);
        Task<int> UpdateFullOpportunity(OpportunityDTO opportunityDTO);
        Task<int> DeleteOpportunity(Guid Id);
    }
}
