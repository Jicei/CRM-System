using System;

namespace CRM.BLL.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentRoleId { get; set; }
    }
}
