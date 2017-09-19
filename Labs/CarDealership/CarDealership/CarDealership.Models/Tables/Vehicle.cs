using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public string Vin { get; set; }
        public int ModelId { get; set; }
        public string Year { get; set; }
        public bool IsNew { get; set; }
        public int PurchaseId { get; set; }
        public decimal Msrp { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public string Description { get; set; }
        public string BodyStyle { get; set; }
        public string PictureFileName { get; set; }
        public bool IsFeatured { get; set; }
    }
}
