using System;

namespace CRM_System.Model
{
    public class OpportunityViewModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid? TypeId { get; set; }
        public TimeSpan TimeWait { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public Guid? ContactId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}
