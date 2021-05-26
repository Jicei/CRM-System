using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public EmployeeService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployee()
        {
            var employees = await db.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }
        public async Task<EmployeeDTO> GetEmployeeById(Guid id)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<EmployeeDTO>(employee);
        }
        public async Task<int> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            await db.Employees.AddAsync(employee);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employeeMapper = _mapper.Map<Employee>(employeeDTO);

            var employee = await db.Employees.FirstOrDefaultAsync(c => c.Id == employeeMapper.Id);
            if (employee == null) throw new Exception("Employee not found");

            employee.Name = employeeDTO.Name != null ? employeeDTO.Name : employee.Name;
            employee.SurName = employeeDTO.SurName != null ? employeeDTO.SurName : employee.SurName;
            employee.Patronymic = employeeDTO.Patronymic != null ? employeeDTO.Patronymic : employee.Patronymic;
            employee.Email = employeeDTO.Email != null ? employeeDTO.Email : employee.Email;
            employee.Telephone = employeeDTO.Telephone != null ? employeeDTO.Telephone : employee.Telephone;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullEmployee(EmployeeDTO employeeDTO)
        {
            var employeeMapper = _mapper.Map<Employee>(employeeDTO);

            var employee = await db.Employees.FirstOrDefaultAsync(c => c.Id == employeeMapper.Id);
            if (employee == null) throw new Exception("Employee not found");

            employee.Name = employeeDTO.Name;
            employee.SurName = employeeDTO.SurName;
            employee.Patronymic = employeeDTO.Patronymic;
            employee.Email = employeeDTO.Email;
            employee.Telephone = employeeDTO.Telephone;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteEmployee(Guid Id)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(c => c.Id == Id);
            if (employee == null) throw new Exception("Employee not found");

            db.Employees.Remove(employee);

            return await db.SaveChangesAsync();
        }

    }
}
