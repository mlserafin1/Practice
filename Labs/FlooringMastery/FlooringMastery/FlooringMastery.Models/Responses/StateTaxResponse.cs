using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringMastery.Models
{
    public class StateTaxResponse : IResponse
    {
        public StateTax StateTaxes { get; set; }

        public StateTaxResponse()
        {
            this.StateTaxes = new StateTax();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
