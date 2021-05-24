using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Desctiption { get; set; }
        public Company Company { get; set; }
        public Guid? CompanyId { get; set; }
        public Country Country { get; set; }
        public Guid? CountryId { get; set; }
        public Employee Responsible { get; set; }
        public Guid? ResponsibleId { get; set; }
        public City City { get; set; }
        public Guid? CityId { get; set; }
        public List<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
        public List<ActivityManager> ActivityManagers { get; set; } = new List<ActivityManager>();
    }
}
