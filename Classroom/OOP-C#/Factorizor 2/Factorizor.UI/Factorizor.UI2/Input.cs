using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    public class Input
    {
        FactorFinder factor = new FactorFinder();
    
        int testNum;
        string temp;

        public void GetIntFromUser()
        {
            
            Console.Write("Enter a number to factor: ");
            temp = Console.ReadLine();
            int.TryParse(temp, out testNum);
            int[] tempArray = new int[factor.count];
            tempArray = factor.FindTheFactors(testNum);
            
            
            for (int i = 0; i < factor.count; i++)
            {
                Console.WriteLine($"{tempArray[i]}");
            }
        }

        
    }
}
