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
    public class EmployeeInRoleService : IEmployeeInRoleService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public EmployeeInRoleService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeInRoleDTO>> GetAllEmployeeInRole()
        {
            var employeesInRole = await db.EmployeeInRoles.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeInRoleDTO>>(employeesInRole);
        }
        public async Task<EmployeeInRoleDTO> GetEmployeeInRoleById(Guid id)
        {
            var employeesInRole = await db.EmployeeInRoles.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<EmployeeInRoleDTO>(employeesInRole);
        }
        public async Task<int> CreateEmployeeInRole(EmployeeInRoleDTO employeeInRoleDTO)
        {
            var employeeInRole = _mapper.Map<EmployeeInRole>(employeeInRoleDTO);
            await db.EmployeeInRoles.AddAsync(employeeInRole);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateEmployeeInRole(EmployeeInRoleDTO employeeInRoleDTO)
        {
            var employeeInRoleMapper = _mapper.Map<EmployeeInRole>(employeeInRoleDTO);

            var employeeInRole = await db.EmployeeInRoles.FirstOrDefaultAsync(c => c.Id == employeeInRoleMapper.Id);
            if (employeeInRole == null) throw new Exception("Employee In Role not found");


            employeeInRole.EmployeeId = employeeInRoleDTO.EmployeeId != null ? employeeInRoleDTO.EmployeeId : employeeInRole.EmployeeId;
            employeeInRole.RoleId = employeeInRoleDTO.RoleId != null ? employeeInRoleDTO.RoleId : employeeInRole.RoleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullEmployeeInRole(EmployeeInRoleDTO employeeInRoleDTO)
        {
            var employeeInRoleMapper = _mapper.Map<EmployeeInRole>(employeeInRoleDTO);

            var employeeInRole = await db.EmployeeInRoles.FirstOrDefaultAsync(c => c.Id == employeeInRoleMapper.Id);
            if (employeeInRole == null) throw new Exception("Employee In Role not found");

            employeeInRole.EmployeeId = employeeInRoleDTO.EmployeeId;
            employeeInRole.RoleId = employeeInRoleDTO.RoleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteEmployeeInRole(Guid Id)
        {
            var employeeInRole = await db.EmployeeInRoles.FirstOrDefaultAsync(c => c.Id == Id);
            if (employeeInRole == null) throw new Exception("Employee In Role not found");

            db.EmployeeInRoles.Remove(employeeInRole);

            return await db.SaveChangesAsync();
        }

    }
}
