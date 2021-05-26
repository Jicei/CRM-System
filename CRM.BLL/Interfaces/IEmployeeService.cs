using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployee();
        Task<EmployeeDTO> GetEmployeeById(Guid id);
        Task<int> CreateEmployee(EmployeeDTO employeeDTO);
        Task<int> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<int> UpdateFullEmployee(EmployeeDTO employeeDTO);
        Task<int> DeleteEmployee(Guid Id);
    }
}
