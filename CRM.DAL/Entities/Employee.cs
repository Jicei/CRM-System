using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Queue> Queue { get; set; } = new List<Queue>();
        public List<EmployeeInRole> EmployeeInRole { get; set; } = new List<EmployeeInRole>();
        public List<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
        public List<ActivityManager> ActivityManagers { get; set; } = new List<ActivityManager>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
