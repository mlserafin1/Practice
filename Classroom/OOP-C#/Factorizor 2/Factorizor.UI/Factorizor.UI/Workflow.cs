using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;


namespace Factorizor.UI
{
    public class Workflow
    {
        Input inpu = new Input();
        Output outp = new Output();
        
        PerfectChecker perfect = new PerfectChecker();
        PrimeChecker prime = new PrimeChecker();

        public void Run()
        {
            inpu.GetIntFromUser();
        }
    }
}
