using System;

namespace CRM_System.Model
{
    public class RoleViewModel
    {
        public string Name { get; set; }
        public Guid? ParentRoleId { get; set; }
    }
}
