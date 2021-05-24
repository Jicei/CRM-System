using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.DAL.Entities
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentRoleId { get; set; }
        public Role ParentRole { get; set; }
        public List<EmployeeInRole> EmployeeInRole { get; set; } = new List<EmployeeInRole>();
    }
}
