using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioInvestimentos.Models
{
    public class YahooResult
    {
        public string Error { get; set; }

        public List<YahooQuote> Result { get; set; }
    }
}
