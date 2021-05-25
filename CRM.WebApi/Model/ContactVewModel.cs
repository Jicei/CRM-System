using System;

namespace CRM_System.Model
{
    public class ContactViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ResponsibleId { get; set; }
        public Guid? CityId { get; set; }
    }
}
