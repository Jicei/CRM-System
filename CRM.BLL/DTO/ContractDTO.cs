using System;

namespace CRM.BLL.DTO
{
    public class ContractDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid? ResponsibleId { get; set; }
        public Guid? OpportunityId { get; set; }
    }
}
