using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class EmployeeInRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public Guid? EmployeeId { get; set; }
        public Role Role { get; set; }
        [Required]
        public Guid? RoleId { get; set; }

    }
}
