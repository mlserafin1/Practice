using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.UI
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            bool validate = true;
            OrderResponse orderResponse = new OrderResponse();
            Order order = new Order();
            DateTime tempDate = DateTime.MinValue;
            string displayDate = null;
            string newDate = null;
            string name = null;
            string state = null;
            string productType = null;
            decimal area = 0;

            Console.Clear();
            
            while (validate)
            {
                ConsoleIO.Display("Add an Order");
                ConsoleIO.Display("-------------------");
                string date = ConsoleIO.Prompt("Enter an order date (must be in the future): ");
 
                DateTime.TryParse(date,out tempDate);
                newDate = tempDate.ToString("MMddyyyy");
                name = ConsoleIO.Prompt("Enter customer name: ");
                state = ConsoleIO.Prompt("Enter state(ex. MI): ").ToUpper();

                List<Product> products = manager.GetAllProducts();
                ConsoleIO.DisplayProducts(products);
                productType = ConsoleIO.Prompt("Enter a product type(ex. Wood): ");
                decimal.TryParse(ConsoleIO.Prompt("Enter an area in square feet (minimum order is 100 ft^2): "), out area);
                orderResponse = manager.CreateOrder(newDate, name, state, productType, area);
                if (orderResponse.Success == false)
                {
                    ConsoleIO.Display(orderResponse.Message);
                    ConsoleIO.Display("Please enter your information again.");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (orderResponse.Success == true)
                {
                    validate = false;
                }
            }
            
            if (orderResponse.Success == false)
            {
                ConsoleIO.Display(orderResponse.Message);
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            displayDate = tempDate.ToString("MM/dd/yyyy");
            order = orderResponse.Order;
            order.Date = newDate;
            Console.Clear();
            ConsoleIO.DisplayAnOrder(order,displayDate);
            string promptToSave = ConsoleIO.Prompt("Would you like to save this order? (Y/N)").ToUpper();
            if (promptToSave == "Y")
            {
                OrderLookupResponse response = manager.LookupOrders(newDate);
                if (response.Success == true)
                {

                    List<Order> ordersUpdated = new List<Order>();
                    ordersUpdated.AddRange(response.Orders);
                    ordersUpdated.Add(order);
                    manager.SaveNewOrder(ordersUpdated);
                }
                else
                {
                    List<Order> orders = new List<Order>();
                    orders.Add(order);
                    manager.SaveNewOrder(orders);
                }

                ConsoleIO.Display("Order Saved!");
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                ConsoleIO.Display("Order abandoned!");
                ConsoleIO.Display("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
