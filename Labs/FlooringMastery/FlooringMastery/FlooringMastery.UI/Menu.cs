using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.UI.WorkFlows;

namespace FlooringMastery.UI
{
    class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("Flooring Program");
                Console.WriteLine("--------------------\n");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit\n");
                Console.Write("Enter selection: ");

                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1":
                        GetOrderWorkflow getOrderWorkflow = new GetOrderWorkflow();
                        getOrderWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                        addOrderWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                        editOrderWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                        removeOrderWorkflow.Execute();
                        break;
                    case "5":
                    case "q":
                    case "Q":
                        return;
                }
            }
        }
    }
}
