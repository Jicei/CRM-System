using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.BLL.DTO
{
    public class LeadTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
