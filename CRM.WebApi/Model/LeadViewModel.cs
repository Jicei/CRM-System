using System;

namespace CRM_System.Model
{
    public class LeadViewModel
    {
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid? ActivityId { get; set; }
    }
}
