using System;

namespace CRM_System.Model
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public float Remains { get; set; }
        public Guid? ResponsibleId { get; set; }
    }
}
