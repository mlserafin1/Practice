using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.UI
{
    public class ConsoleIO
    {
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static string Prompt(string message)
        {
            string result = "";
            while (result == "")
            {
                Display(message);
                result = Console.ReadLine();
            }
            return result;
        }
        
    }
}
