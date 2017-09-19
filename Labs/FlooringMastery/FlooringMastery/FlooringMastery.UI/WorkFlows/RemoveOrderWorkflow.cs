using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI.WorkFlows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            int orderNumber;
            Console.Clear();
            ConsoleIO.Display("Remove an Order");
            ConsoleIO.Display("-------------------");
            string date = ConsoleIO.Prompt("Enter an order date: ");
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
            int.TryParse(ConsoleIO.Prompt("Enter the order number of the order you wish to delete: "),out orderNumber);
            Console.Clear();
            


            OrderResponse response = new OrderResponse();
            response = manager.GetSingleOrder(newDate, orderNumber);
            if (response.Success == false)
            {
                ConsoleIO.Display(response.Message);
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            ConsoleIO.DisplayAnOrder(response.Order,displayDate);
            string promptToDelete = ConsoleIO.Prompt("Would you like to delete this order? (Y/N)").ToUpper();
            if (promptToDelete == "Y")
            {
                manager.DeleteOrder(response.Order);
                ConsoleIO.Display("Order deleted!");
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if(promptToDelete == "N")
            {
                ConsoleIO.Display("Order was not deleted.");
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
    }
}
