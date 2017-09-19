using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystems
{
    public static class ConsoleIO
    {
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static string Prompt(string prompt)
        {
            Display(prompt);
            return Console.ReadLine();
        }

        public static string Prompt(string prompt, bool IsRequired)
        {
            string result = "";
            while (string.IsNullOrEmpty(result = Prompt(prompt)) && IsRequired)
            {
                Display("Input is required");
            }
            return result;
        }

        public static void WaitKey(string message)
        {
            Display(message);
            Console.ReadKey();
        }
    }
}
