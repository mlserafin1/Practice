using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchaseDate { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public int CustomerInfoId { get; set; }
        public decimal Price { get; set; }
    }
}
