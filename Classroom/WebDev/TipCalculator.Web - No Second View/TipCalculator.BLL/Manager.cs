using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Models;

namespace TipCalculator.BLL
{
    public class Manager
    {
        public decimal CalculateTip(decimal total, decimal percent)
        {
            decimal calcTip = total + (total * (percent / 100));
            return calcTip;
        }
    }
}
