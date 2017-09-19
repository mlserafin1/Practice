using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public class GetOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            ConsoleIO.Display("Display Orders");
            ConsoleIO.Display("-------------------");

            string date = ConsoleIO.Prompt("Enter an order date: ");

            DateTime ordDate;
            DateTime.TryParse(date,out ordDate);
            string newDate = ordDate.ToString("MMddyyyy");
            string displayDate = ordDate.ToString("MM/dd/yyyy");

            OrderLookupResponse orders = new OrderLookupResponse();
            orders  = manager.LookupOrders(newDate);

            if (orders.Success == false)
            {
                ConsoleIO.Display(orders.Message);
            }
            else if (orders.Orders.Count == 0)
            {
                ConsoleIO.Display("There are no orders for the date you entered.");
            }
            else
            {
                Console.Clear();
                ConsoleIO.DisplayAllOrders(orders.Orders,displayDate);
            }

            ConsoleIO.Prompt("Press any key to continue...");
            Console.Clear();
        }
    }
}
