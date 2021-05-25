using System;

namespace CRM_System.Controllers
{
    public class ActivityManagerViewModel
    {
        public string Name { get; set; }
        public Guid? ActivityManagerTypeId { get; set; }
        public string Description { get; set; }
        public Guid? ContactId { get; set; }
        public Guid? LeadId { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}