using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class ProductInOpportunity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Opportunity Opportunity { get; set; }
        [Required]
        public Guid? OpportunityId { get; set; }
        public Product Product { get; set; }
        [Required]
        public Guid? ProductId { get; set; }
    }
}