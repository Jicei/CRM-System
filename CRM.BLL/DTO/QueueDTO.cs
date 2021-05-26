using System;

namespace CRM.BLL.DTO
{
    public class QueueDTO
    {
        public Guid Id { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateTimeStartCall { get; set; }
        public TimeSpan TimeWait { get; set; }
        public DateTime DateStartAnswer { get; set; }
        public DateTime DateEndAnswer { get; set; }
        public Guid? ResponsibleId { get; set; }
        public string Description { get; set; }
    }
}
