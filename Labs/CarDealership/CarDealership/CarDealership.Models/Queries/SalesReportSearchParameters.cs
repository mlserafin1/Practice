using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class SalesReportSearchParameters
    {
        public string UserId { get; set; }
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
    }
}
