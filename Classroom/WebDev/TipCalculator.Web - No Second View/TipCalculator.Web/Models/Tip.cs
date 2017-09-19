using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Web.Models
{
    public class Tip
    {
        public decimal BillTotal { get; set; }
        public decimal TipPercent { get; set; }
        public decimal CalculatedTip { get; set; }
    }
}