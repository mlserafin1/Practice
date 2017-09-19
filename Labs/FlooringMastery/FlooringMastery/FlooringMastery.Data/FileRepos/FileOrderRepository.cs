using System;
using System.Collections.Generic;
using System.IO;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        private string _fileName;

        

        public FileOrderRepository(string filename)
        {
            _fileName = filename;
        }

        public List<Order> LoadOrders(string date)
        {

            List<Order> orders = new List<Order>();
            


            string fullFilePath = _fileName + "Orders_" + date + ".txt";
            if (!File.Exists(fullFilePath))
            {
                orders = null;
                return orders;
            }

            using (StreamReader sr = new StreamReader(fullFilePath))
            {
                
                    sr.ReadLine();
                    string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Order order = new Order();

                    string[] fields = line.Split('|');

                    try
                    {
                        order.OrderNumber = int.Parse(fields[0]);
                        order.CustomerName = fields[1];
                        order.State = fields[2];
                        order.TaxRate = decimal.Parse(fields[3]);
                        order.ProductType = fields[4];
                        order.Area = decimal.Parse(fields[5]);
                        order.CostPerSquareFoot = decimal.Parse(fields[6]);
                        order.LaborCostPerSquareFoot = decimal.Parse(fields[7]);
                        order.MaterialCost = decimal.Parse(fields[8]);
                        order.LaborCost = decimal.Parse(fields[9]);
                        order.Tax = decimal.Parse(fields[10]);
                        order.Total = decimal.Parse(fields[11]);
                        order.Date = date;

                        orders.Add(order);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message +
                                          " Contact IT."); //wont console write message if the error occurs anywhere other than the first string in file
                    }
                }
            }
            return orders;
        }


        public void SaveOrder(List<Order> orders, string date)
        {
            
            string fullFilePath = _fileName + "Orders_" + date + ".txt";
            if (orders.Count == 0)
            {
                File.Delete(fullFilePath);
                return;
            }
            
                using (StreamWriter sw = new StreamWriter(fullFilePath,false))
                {
                    
                    sw.WriteLine(
                        "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    foreach (var order in orders)
                    {
                        sw.WriteLine(
                            $"{order.OrderNumber}|{order.CustomerName}|{order.State}|{order.TaxRate}|{order.ProductType}|{order.Area}|{order.CostPerSquareFoot}|{order.LaborCostPerSquareFoot}|{order.MaterialCost}|{order.LaborCost}|{order.Tax}|{order.Total}");
                    }
                    
                }
            
            
        }
    }
}
