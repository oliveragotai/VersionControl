using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnbCurrencyReader.Entities
{
    public class RateData
    {
        public DateTime Date { get; set; }
        public String Currency { get; set; }
        public Decimal Value { get; set; }
    }
}
