using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_System.Model
{
    public class ActivityViewModel
    {
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid? TypeActivityId { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}
