using System;

namespace CRM.BLL.DTO
{
    public class ProductABCFMRAnalysisDTO
    {
        public Guid ProductId { get; set; } 
        public string ProductName { get; set; }
        public float Amount { get; set; }
        public float PartAmount { get; set; }
        public float Quantity { get; set; }
        public float PartQuantity { get; set; }
        public string Category { get; set; }
    }
}
