using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            int orderNumber;
            string answer;
            decimal areaAnswer;
            bool validate = true;

            OrderManager manager = OrderManagerFactory.Create();
            OrderResponse editResponse = new OrderResponse();
            Console.Clear();
            ConsoleIO.Display("Edit an Order");
            ConsoleIO.Display("-------------------");
            string date = ConsoleIO.Prompt("Enter an order date: ");
            Console.Clear();
            DateTime ordDate;
            DateTime.TryParse(date, out ordDate);
            string newDate = ordDate.ToString("MMddyyyy");
            string displayDate = ordDate.ToString("MM/dd/yyyy");
            OrderLookupResponse display = manager.LookupOrders(newDate);
            if (display.Success == false)
            {
                ConsoleIO.Display(display.Message);
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            ConsoleIO.DisplayAllOrders(display.Orders,displayDate);
            int.TryParse(ConsoleIO.Prompt("Enter the order number of the order you wish to edit: "), out orderNumber);


            OrderResponse fraudCheck = manager.EditFraudCheck(ordDate);
            if (fraudCheck.Success == false)
            {
                ConsoleIO.Display(fraudCheck.Message);
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }


            OrderResponse response = new OrderResponse();

            Console.Clear();
            while (validate)
            {
                
                response = manager.GetSingleOrder(newDate, orderNumber);
                if (response.Success == false)
                {
                    ConsoleIO.Display(response.Message);
                    ConsoleIO.Display("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                ConsoleIO.DisplayAnOrder(response.Order, displayDate);
                answer = ConsoleIO.Prompt($"Enter customer name (it is currently {response.Order.CustomerName}): ");
                if (!string.IsNullOrEmpty(answer))
                {
                    response.Order.CustomerName = answer;
                }
                Console.Clear();
                ConsoleIO.DisplayAnOrder(response.Order, displayDate);
                answer = ConsoleIO.Prompt($"Enter state (it is currently {response.Order.State}): ");
                if (!string.IsNullOrEmpty(answer))
                {
                    response.Order.State = answer;
                }
                Console.Clear();
                ConsoleIO.DisplayAnOrder(response.Order, displayDate);
                answer = ConsoleIO.Prompt($"Enter product (it is currently {response.Order.ProductType}): ");
                if (!string.IsNullOrEmpty(answer))
                {
                    response.Order.ProductType = answer;
                }
                Console.Clear();
                ConsoleIO.DisplayAnOrder(response.Order, displayDate);
                answer = ConsoleIO.Prompt($"Edit area (it is currently {response.Order.Area} ft^2): ");
                if (!string.IsNullOrEmpty(answer))
                {
                    decimal.TryParse(answer, out areaAnswer);
                    response.Order.Area = areaAnswer;
                }
                Console.Clear();
                editResponse = manager.CreateEditedOrder(response.Order);
                if (editResponse.Success == false)
                {
                    ConsoleIO.Display(editResponse.Message);
                    ConsoleIO.Display("Let's try that again, shall we?");
                    ConsoleIO.Display("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    if (editResponse.Success == true)
                    {
                        editResponse.Order.OrderNumber = response.Order.OrderNumber;
                        editResponse.Order.Date = response.Order.Date;
                        validate = false;

                    }
                }
            }
            Console.Clear();
            ConsoleIO.DisplayAnOrder(editResponse.Order,displayDate);
            string edit = ConsoleIO.Prompt("Would you like to save this edited order (Y/N): ").ToUpper();
            switch (edit)
            {
                case "Y":
                    manager.SaveEditedOrder(editResponse.Order, newDate);
                    ConsoleIO.Display("Order upated!");
                    ConsoleIO.Display("Press any key to continue...");
                    Console.ReadKey();
                    break;
                default:
                    ConsoleIO.Display("Edit order abandoned!");
                    ConsoleIO.Display("Press any key to continue...");
                    Console.ReadKey();
                    break;

            }
            Console.Clear();

        }
    }
}
