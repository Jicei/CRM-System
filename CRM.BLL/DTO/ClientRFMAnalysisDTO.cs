using System;

namespace CRM.BLL.DTO
{
    public class ClientRFMAnalysisDTO
    {
        public Guid? ClientId { get; set; }
        public bool IsFisicalClient { get; set; }
        public DateTime Recency { get; set; }
        public int Frequency { get; set; }
        public float MonetaryValue { get; set; }
        public string Class { get; set; }
    }
}
