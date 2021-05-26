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
    public class RoleService: IRoleService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public RoleService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDTO>> GetAllRole()
        {
            var roles = await db.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }
        public async Task<RoleDTO> GetRoleById(Guid id)
        {
            var role = await db.Roles.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<RoleDTO>(role);
        }
        public async Task<int> CreateRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            await db.Roles.AddAsync(role);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateRole(RoleDTO roleDTO)
        {
            var roleMapper = _mapper.Map<Role>(roleDTO);

            var role = await db.Roles.FirstOrDefaultAsync(c => c.Id == roleMapper.Id);
            if (role == null) throw new Exception("Role not found");

            role.Name = roleDTO.Name != null ? roleDTO.Name : role.Name;
            role.ParentRoleId = roleDTO.ParentRoleId != null ? roleDTO.ParentRoleId : role.ParentRoleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullRole(RoleDTO roleDTO)
        {
            var roleMapper = _mapper.Map<Role>(roleDTO);

            var role = await db.Roles.FirstOrDefaultAsync(c => c.Id == roleMapper.Id);
            if (role == null) throw new Exception("Role not found");

            role.Name = roleDTO.Name;
            role.ParentRoleId = roleDTO.ParentRoleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteRole(Guid Id)
        {
            var role = await db.Roles.FirstOrDefaultAsync(c => c.Id == Id);
            if (role == null) throw new Exception("Role not found");

            db.Roles.Remove(role);

            return await db.SaveChangesAsync();
        }

    }
}
