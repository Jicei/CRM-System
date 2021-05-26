using CRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDTO>> GetAllContract();
        Task<ContractDTO> GetContractById(Guid id);
        Task<int> CreateContract(ContractDTO contractDTO);
        Task<int> UpdateContract(ContractDTO contractDTO);
        Task<int> UpdateFullContract(ContractDTO contractDTO);
        Task<int> DeleteContract(Guid Id);
    }
}
