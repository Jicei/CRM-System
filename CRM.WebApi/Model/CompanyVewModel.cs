using System;

namespace CRM_System.Model
{
    public class CompanyViewModel
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Guid? ResponsibleId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? LeadId { get; set; }
    }
}
