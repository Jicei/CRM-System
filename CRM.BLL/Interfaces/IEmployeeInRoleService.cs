using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IEmployeeInRoleService
    {
        Task<IEnumerable<EmployeeInRoleDTO>> GetAllEmployeeInRole();
        Task<EmployeeInRoleDTO> GetEmployeeInRoleById(Guid id);
        Task<int> CreateEmployeeInRole(EmployeeInRoleDTO employeeInRoleDTO);
        Task<int> UpdateEmployeeInRole(EmployeeInRoleDTO employeeInRoleDTO);
        Task<int> UpdateFullEmployeeInRole(EmployeeInRoleDTO employeeInRoleDTO);
        Task<int> DeleteEmployeeInRole(Guid Id);
    }
}
