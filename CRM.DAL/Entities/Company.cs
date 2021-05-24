using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Employee Responsible { get; set; }
        public Guid? ResponsibleId { get; set; }
        public Country Country { get; set; }
        public Guid? CountryId { get; set; }
        public City City { get; set; }
        public Guid? CityId { get; set; }
        public Lead Lead { get; set; }
        public Guid? LeadId { get; set; }
        public List<Contact> Conatact { get; set; } = new List<Contact>();
        public List<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
    }
}
