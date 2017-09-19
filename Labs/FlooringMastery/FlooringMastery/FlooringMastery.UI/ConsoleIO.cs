using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.UI
{
    public class ConsoleIO
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

        public static void DisplayProducts(List<Product> prodList)
        {
            if (prodList == null)
            {
                ConsoleIO.Display("Product list is empty. Contact IT.");
                return;
            }
            Console.WriteLine("------------------------------------");
            foreach (var prod in prodList)
            {
                Console.WriteLine($"Product Type: {prod.productType}");
                Console.WriteLine($"Cost per ft^2: {prod.costPerSquareFoot:C}");
                Console.WriteLine($"Labor cost per ft^2: {prod.laborCostPerSquareFoot:C}");
                Console.WriteLine("------------------------------------");
            }

        }

        public static void DisplayAnOrder(Order order, string date)
        {
            Console.WriteLine($"{order.OrderNumber} | {date}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:C}");
            Console.WriteLine($"Labor: {order.LaborCost:C}");
            Console.WriteLine($"Tax: {order.Tax:C}");
            Console.WriteLine($"Total: {order.Total:C}\n");
        }

        public static void DisplayAllOrders(List<Order> orders, string displayDate)
        {
            if (orders == null)
            {
                ConsoleIO.Display("There are no orders for the date entered.");
                return;
            }
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.OrderNumber} | {displayDate}");
                Console.WriteLine($"{o.CustomerName}");
                Console.WriteLine($"{o.State}");
                Console.WriteLine($"Product: {o.ProductType}");
                Console.WriteLine($"Materials: {o.MaterialCost:C}");
                Console.WriteLine($"Labor: {o.LaborCost:C}");
                Console.WriteLine($"Tax: {o.Tax:C}");
                Console.WriteLine($"Total: {o.Total:C}\n");
            }
        }

    }
}
