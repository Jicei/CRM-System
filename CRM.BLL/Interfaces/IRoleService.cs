using CRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRole();
        Task<RoleDTO> GetRoleById(Guid id);
        Task<int> CreateRole(RoleDTO roleDTO);
        Task<int> UpdateRole(RoleDTO roleDTO);
        Task<int> UpdateFullRole(RoleDTO roleDTO);
        Task<int> DeleteRole(Guid Id);
    }
}
