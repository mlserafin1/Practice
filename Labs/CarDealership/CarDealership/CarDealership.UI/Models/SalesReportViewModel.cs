using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class SalesReportViewModel
    {
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SalesReport> Sales { get; set; }
        public SalesReportSearchParameters Parameters { get; set; }
    }
}