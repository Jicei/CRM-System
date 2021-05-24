using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.BLL.DTO
{
    public class CityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CountryId { get; set; }
    }
}
