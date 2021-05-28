using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.DAL.Entities
{
    public class Lead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public LeadType Type { get; set; }
        public Guid? TypeId { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Activity Activity { get; set; }
        public Guid? ActivityId { get; set; }
        public List<Activity> Activities = new List<Activity>();
        public List<Company> Companies = new List<Company>();
        public List<ActivityManager> ActivityManagers { get; set; } = new List<ActivityManager>();
    }
}
