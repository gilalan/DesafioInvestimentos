using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioInvestimentos.Models
{
    public class YahooQuote
    {
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Symbol { get; set; }

        public double RegularMarketPrice { get; set; }

        public string DisplayName { get; set; }
    }
}
