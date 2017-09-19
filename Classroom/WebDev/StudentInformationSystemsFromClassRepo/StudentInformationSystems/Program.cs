using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystems.Workflows;

namespace StudentInformationSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkFlow workflow = null;
            string choice = ConsoleIO.Prompt("1.Display Students\n2.Add Student\n3.Remove Student\nq for quit");
            switch (choice)
            {
                case "1":
                    workflow = new DisplayWorkFlow();
                    break;
                case "2":
                    workflow = new AddWorkFlow();
                    break;
                case "3":
                    workflow = new RemoveWorkFlow();
                    break;
                case "q":
                    ConsoleIO.Display("Thank you, come again!");
                    break;
                default:
                    ConsoleIO.Display("Invalid Choice");
                    break;
            }
            if (workflow != null)
            {
                workflow.Execute();
            }
            ConsoleIO.WaitKey("Press any key to continue.");
        }
    }
}
