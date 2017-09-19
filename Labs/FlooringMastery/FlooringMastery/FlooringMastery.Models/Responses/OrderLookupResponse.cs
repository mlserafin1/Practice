using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringMastery.Models
{
    public class OrderLookupResponse : IResponse
    {
        public List<Order> Orders { get; set; }

        public OrderLookupResponse() // need to create a new list, when we instantiate new orderlookup response, we have not instantiated a new non-simple type list that exists within the response. It will throw a null exception.
        {
            this.Orders = new List<Order>();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
