using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarparkCalculation.BusinessLayer
{
    public class StandardRate : IParkingRate
    {
        public string Name { get; set; }
        public RateType Type { get; set; }
        public decimal TotalPrice { get; set; }

        public StandardRate(string name)
        {
            Name = name;
            Type = RateType.HourlyRate;
        }
    }
}
