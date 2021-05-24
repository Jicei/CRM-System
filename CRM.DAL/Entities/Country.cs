using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<City> Cities { get; set; } = new List<City>();
        public List<Contact> Contact { get; set; } = new List<Contact>();
    }
}
