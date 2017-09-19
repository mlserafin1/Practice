using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator.Models
{
    public class Tip
    {
        public decimal BillTotal { get; set; }
        public decimal TipPercent { get; set; }
        public decimal CalculatedTip { get; set; }
    }
}
