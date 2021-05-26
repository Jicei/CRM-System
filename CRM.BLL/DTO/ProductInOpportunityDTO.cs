using System;

namespace CRM.BLL.DTO
{
    public class ProductInOpportunityDTO
    {
        public Guid Id { get; set; }
        public Guid? OpportunityId { get; set; }
        public Guid? ProductId { get; set; }
    }
}