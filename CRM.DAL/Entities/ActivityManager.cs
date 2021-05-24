using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.DAL.Entities
{
    public class ActivityManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ActivityManagerType ActivityManagerType { get; set; }
        public Guid? ActivityManagerTypeId { get; set; }
        public string Description { get; set; }
        public Guid? ContactId { get; set;}
        public Contact Contact { get; set; }
        public Guid? LeadId { get; set; }
        public Lead Lead { get; set; }
        public Employee Resposible { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}
