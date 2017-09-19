using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class ProductResponse : IResponse
    {
        public List<Product> Products { get; set; }

        public ProductResponse()
        {
            this.Products = new List<Product>();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
