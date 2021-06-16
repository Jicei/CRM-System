using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.BLL.DTO
{
    public class SeasonalityQuarter
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public float Amount { get; set; }
        public float Average { get; set; }
        public float CentralizeAverage { get; set; }
        public float SeasonalityIndex { get; set; }
    }
}
