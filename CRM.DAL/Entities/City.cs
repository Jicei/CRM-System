using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Country Country { get; set; }
        public Guid? CountryId { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Contact> Contact { get; set; } = new List<Contact>();
    }
}
