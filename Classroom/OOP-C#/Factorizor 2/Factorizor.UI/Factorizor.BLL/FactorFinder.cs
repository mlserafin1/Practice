using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Factorizor.BLL
{
    public class FactorFinder
    {
        public int testNumFactor;
        public int count = 0;
        public int[] FindTheFactors(int testNumFactor)
        {
            int[] holder = new int[testNumFactor/2];
            for (int i = 1; i <= testNumFactor; i++)
            {
                if (testNumFactor % i == 0)
                {
                    holder[count] = i;
                    count++;
                }
            }
            return holder;
        }
    }
}
