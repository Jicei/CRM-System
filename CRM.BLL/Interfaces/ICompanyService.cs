using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetAllCompany();
        Task<CompanyDTO> GetCompanyById(Guid id);
        Task<int> CreateCompany(CompanyDTO companyDTO);
        Task<int> UpdateCompany(CompanyDTO companyDTO);
        Task<int> UpdateFullCompany(CompanyDTO companyDTO);
        Task<int> DeleteCompany(Guid Id);
    }
}
