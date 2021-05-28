using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.BLL.DTO
{
    public class OpportunityDTO
    {
        public Guid Id { get; set; }
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
