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
        int testNum;
        string temp;

        public void GetIntFromUser()
        {
            FactorFinder factor = new FactorFinder();
            Console.WriteLine("Enter a number to factor: ");
            temp = Console.ReadLine();
            int.TryParse(temp, out testNum);
            factor.testNum = testNum;
        }

    }
}
