using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.BLL.DTO
{
    public class ActivityManagerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ActivityManagerTypeId { get; set; }
        public string Description { get; set; }
        public Guid? ContactId { get; set; }
        public Guid? LeadId { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}
