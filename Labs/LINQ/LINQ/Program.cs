using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13(); //needs work, order by descending order date
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22(); 
            //Exercise23(); 
            //Exercise24();
            //Exercise25(); 
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            //query and query2 do the same thing
            //call Excercise1 in main, when it prints properly, comment it out and move to the next one
            //print method is in the "Sample Code" thing above
            var list = DataLoader.LoadProducts();
            var query = from p in list
                        where p.UnitsInStock == 0
                        select p;
            var query2 = list.Where(p => p.UnitsInStock == 0);
            PrintProductInformation(query);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var list = DataLoader.LoadProducts();
            var query = from p in list
                        where p.UnitsInStock > 0 && p.UnitPrice > 3.00M
                        select p;
            PrintProductInformation(query);


        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers();
            var query = from c in customers
                where c.Region == "WA"
                select c;
            PrintCustomerInformation(query);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = DataLoader.LoadProducts();
            var query = from p in products
                        select new
                        {
                            NameOfProduct = p.ProductName
                        };
            foreach (var pn in query)
            {
                Console.WriteLine("{0}",pn.NameOfProduct);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var list = DataLoader.LoadProducts();
            var query = from p in list
                        select new
                        {
                            Number = p.ProductID,
                            NewPrice = p.UnitPrice*1.25M,
                            Name = p.ProductName,
                            Stock = p.UnitsInStock,
                            Cat = p.Category
                        };
            foreach (var n in query)
            {
                Console.WriteLine("{0}, {1}, {2}, {3:C}, {4}",n.Number,n.Name,n.Cat,n.NewPrice,n.Stock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var list = DataLoader.LoadProducts();
            var query = from p in list
                select new
                {
                    Name = p.ProductName.ToUpper(),
                    Cat = p.Category.ToUpper()
                };
            foreach (var u in query)
            {
                Console.WriteLine("{0}, {1}",u.Name,u.Cat);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var list = DataLoader.LoadProducts();
            var query = from p in list
                select new
                {
                    ID = p.ProductID,
                    Name = p.ProductName,
                    Cat = p.Category,
                    Price = p.UnitPrice,
                    Stock = p.UnitsInStock,
                    ReOrder = (p.UnitsInStock < 3)
                };
            foreach (var s in query)
            {
                Console.WriteLine("{0}, {1}, {2}, {3:N2}, {4}, {5}",s.ID,s.Name,s.Cat,s.Price,s.Stock,s.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var list = DataLoader.LoadProducts();
            var query = from p in list
                select new
                {
                    ID = p.ProductID,
                    Name = p.ProductName,
                    Cat = p.Category,
                    Price = p.UnitPrice,
                    Stock = p.UnitsInStock,
                    StockValue = p.UnitsInStock * p.UnitPrice
                };
            foreach (var s in query)
            {
                Console.WriteLine("{0}, {1}, {2}, {3:C}, {4}, {5}", s.ID, s.Name, s.Cat, s.Price, s.Stock, s.StockValue);
            }
            
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var list = DataLoader.NumbersA;  //NumbersA = { 0, 2, 4, 5, 6, 8, 9 };
            var query = from n in list
                where n % 2 == 0
                select n;

            foreach (var i in query)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers();
            var query = from c in customers
                where c.Orders.Any(s => s.Total < 500)
                select c;

            PrintCustomerInformation(query);

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var num = DataLoader.NumbersC;  // NumbersC = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var list = (from n in num
                where n % 2 > 0
                select n).Take(3);
            //list = list.Take(3);

            foreach (var n in list)
            {
                Console.WriteLine($"{n}");
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var num = DataLoader.NumbersB;  // NumbersB = { 1, 3, 5, 7, 8 };
            var query = (from n in num
                select n).Skip(3);
            foreach (var i in query)
            {
                Console.WriteLine("{0}",i);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington    //order in descending, take top
        /// </summary>
        static void Exercise13()
        {
            var list = DataLoader.LoadCustomers();
            var query = from c in list
                where c.Region == "WA"
                select new
                {
                    CustomeName = c.CompanyName,
                    RecentOrder = c.Orders.Last()
                };



            foreach (var i in query)
            {
                Console.WriteLine("{0}", i.CustomeName);
                Console.WriteLine("{0},  {1},  {2:C}",i.RecentOrder.OrderDate,i.RecentOrder.OrderID,i.RecentOrder.Total);
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var num = DataLoader.NumbersC;  //NumbersC = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var query = num.TakeWhile(a => a < 6);
            foreach (var i in query)
            {
                Console.WriteLine("{0}",i);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var num = DataLoader.NumbersC;  //NumbersC = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var query = num.SkipWhile(a => a % 3 != 0);
            var query2 = query.Skip(1);
            foreach (var i in query2)
            {
                Console.WriteLine("{0}", i);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var list = DataLoader.LoadProducts();
            var query = list.OrderBy(a => a.ProductName);

            foreach (var i in query)
            {
                Console.WriteLine("{0}",i.ProductName);
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var list = DataLoader.LoadProducts();
            var query = list.OrderByDescending(a => a.UnitsInStock);

            foreach (var i in query)
            {
                Console.WriteLine("{0}, {1}",i.ProductName,i.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var list = DataLoader.LoadProducts();
            var query = list.OrderByDescending(a => a.Category).ThenByDescending(b => b.UnitPrice);

            PrintProductInformation(query);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var num = DataLoader.NumbersB;  //NumbersB = { 1, 3, 5, 7, 8 };
            var query = num.Reverse();

            foreach (var i in query)
            {
                Console.WriteLine("{0}", i);
            }
            
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var list = DataLoader.LoadProducts();
            var query = list.GroupBy(a => a.Category);

            foreach (var i in query)
            {
                Console.WriteLine("{0} ",i.Key);    //key is what we grouped by, in this case category
                Console.WriteLine("--------------------------------");
                foreach (var c in i)    
                {
                    Console.WriteLine("{0}", c.ProductName);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();
            var query = from c in customers
                select new
                {
                    //select new is creating an anonymous type, we are creating the fields customerName, etc.
                    CustomerName = c.CompanyName,
                    OrdersByYear = from o in c.Orders
                                   group o by o.OrderDate.Year into oyg
                                   select new
                                            {
                                                year = oyg.Key,
                                                OrdersByMonth = from oo in oyg
                                                group oo by oo.OrderDate.Month into omg
                                                select new
                                                        {
                                                            Month = omg.Key,
                                                            Orders = omg
                                                        }
                                            }
                };
            foreach (var customer in query)
            {
                Console.WriteLine(customer.CustomerName);
                foreach (var year in customer.OrdersByYear)
                {
                    Console.WriteLine("\t{0}",year.year);
                    foreach (var order in year.OrdersByMonth)
                    {
                        Console.WriteLine("\t{0}",order.Month);
                        foreach (var obm in order.Orders)
                        {
                            Console.WriteLine("\t{0}",obm.Total);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var list = DataLoader.LoadProducts();
            var query = list.Select(a => a.Category).Distinct();

            foreach (var i in query)
            {
                Console.WriteLine("{0}", i);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var list = DataLoader.LoadProducts();
            var hasOrHasNot = list.Any(a => a.ProductID == 789);

            if (hasOrHasNot)
            {
                Console.WriteLine("The product list DOES contains Product #789.");
            }
            else
                Console.WriteLine("The product list DOES NOT contain Product #789.");
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var list = DataLoader.LoadProducts();
            var query = list.Where(a => a.UnitsInStock == 0).Select(a => a.Category).Distinct();

            foreach (var i in query)
            {
                Console.WriteLine("{0}", i);
            }
            Console.WriteLine("-----------------------");
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var list = DataLoader.LoadProducts();
            var query = from p in list
                group p by p.Category
                into g
                where g.All(y => y.UnitsInStock > 0)
                select g;

            foreach (var i in query)
            {
                Console.WriteLine("{0}",i.Key);
            }

            /*var list = DataLoader.LoadProducts();
            var query = (from p in list
                group p.UnitsInStock by p.Category).Distinct();
            var query2 = from c in query
                where c.Min() > 0
                select c;
            foreach (var i in query2)
            {
                Console.WriteLine("{0}", i.Key);
            }*/
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var num = DataLoader.NumbersA;
            var query = from n in num
                where n % 2 != 0
                select n;
            Console.WriteLine("Count of odd numbers in NumbersA = {0}.", query.Count());
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var list = DataLoader.LoadCustomers();
            var query = from c in list
                select new
                {
                    ID = c.CustomerID,
                    Count = c.Orders.Length
                };
            
            foreach (var i in query)
            {
                Console.WriteLine("{0}, {1}",i.ID,i.Count);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var list = DataLoader.LoadProducts();
            var query = list.GroupBy(a => a.Category).Distinct();

            foreach (var i in query)
            {
                Console.WriteLine("{0}, {1}",i.Key,i.Count());
            }
                    
        
            

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var list = DataLoader.LoadProducts();
            var query = list.GroupBy(a => a.Category, b=>b.UnitsInStock).Distinct();

            foreach (var i in query)
            {
                Console.WriteLine("{0}, {1}",i.Key,i.Sum());
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var list = DataLoader.LoadProducts();
            var query = list.GroupBy(a => a.Category, b => b.UnitPrice).Distinct();

            foreach (var i in query)
            {
                Console.WriteLine("{0}, {1:C}", i.Key, i.Min());
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var list = DataLoader.LoadProducts();
            var query = list.GroupBy(p => p.Category, p => p.UnitPrice).Distinct();
            var query2 = (from c in query
                orderby c.Average() descending
                select c).Take(3);  //can do .Select(s=>s.Key) before the .Take(3)
            foreach (var i in query2)
            {
                Console.WriteLine("{0}, {1:C}",i.Key,i.Average());
            }
        }
    }
}
