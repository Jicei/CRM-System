using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ActivityType TypeActivity { get; set; }
        public Guid? TypeActivityId { get; set; }
        public Employee Responsible { get; set; }
        public Guid? ResponsibleId { get; set; }
        public List<Lead> Leads {get; set; }
    }
}
