using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.BLL.DTO
{
    public class LeadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid? ActivityId { get; set; }
    }
}
