using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class StringCalc
    {
        public int Add(string numbers)
        {
            if(numbers == "")
            return 0;

            return int.Parse(numbers);
        }

        
    }
}
