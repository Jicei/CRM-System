using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.DAL.Entities
{
    public class Opportunity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public OpportunityType Type { get; set; }
        public Guid? TypeId { get; set; }
        public bool IsFisicalClient { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public TimeSpan TimeWait { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public Contact Contact { get; set; }
        public Guid? ContactId { get; set; }
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }
        public Employee Responsible { get; set; }
        public Guid? ResponsibleId { get; set; }
        public List<ProductInOpportunity> ProductInOpportunity { get; set; } = new List<ProductInOpportunity>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
