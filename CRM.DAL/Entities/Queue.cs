using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.DAL.Entities
{
    public class Queue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateTimeStartCall { get; set; }
        public TimeSpan TimeWait { get; set; }
        public DateTime DateStartAnswer { get; set; }
        public DateTime DateEndAnswer { get; set; }
        public Employee Responsible { get; set; }
        public Guid? ResponsibleId { get; set; }
        public string Description { get; set; }
    }
}
