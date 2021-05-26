using System;

namespace CRM_System.Model
{
    public class ContractViewModel
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid? ResponsibleId { get; set; }
        public Guid? OpportunityId { get; set; }
    }
}
