using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get;set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Employee Responsible { get; set; }
        public Guid? ResponsibleId { get; set; }
        public Opportunity Opportunity { get; set; }
        public Guid? OpportunityId { get; set; }
    }
}
