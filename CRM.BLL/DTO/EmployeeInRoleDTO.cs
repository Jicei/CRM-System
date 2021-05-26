using System;

namespace CRM.BLL.DTO
{
    public class EmployeeInRoleDTO
    {
        public Guid Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? RoleId { get; set; }

    }
}
