using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class VehicleInventoryReportViewModel
    {
        public IEnumerable<UsedVehicleInventoryReport> Used { get; set; }
        public IEnumerable<NewVehicleInventoryReport> New { get; set; }
    }
}