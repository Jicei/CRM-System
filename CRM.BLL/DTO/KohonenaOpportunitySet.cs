using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.BLL.DTO
{
    public class KohonenaOpportunitySet
    {
        public Guid? ClientId { get; set; }
        public bool IsFisicalClient { get; set; }
        public decimal Recency { get; set; }
        public float Frequency { get; set; }
        public float MonetaryValue { get; set; }
    }
}
