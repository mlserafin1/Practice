using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class FileProductRepository : IProductRepository
    {
        private string _fileName;

        public FileProductRepository(string filename)
        {
            _fileName = filename;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader(_fileName))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product product = new Product();

                    string[] fields = line.Split('|');
                    product.productType = fields[0];
                    product.costPerSquareFoot = decimal.Parse(fields[1]);
                    product.laborCostPerSquareFoot = decimal.Parse(fields[2]);

                    products.Add(product);
                }
            }
            return products;
        }

        public Product GetByName(string productType)
        {
            Product product = new Product();
            product = null;

            using (StreamReader sr = new StreamReader(_fileName))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product temp = new Product();

                    string[] fields = line.Split('|');
                    try
                    {
                        temp.productType = fields[0];
                        temp.costPerSquareFoot = decimal.Parse(fields[1]);
                        temp.laborCostPerSquareFoot = decimal.Parse(fields[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message +
                                          " Contact IT."); //wont console write message if the error occurs anywhere other than the first string in file
                    }

                    if (temp.productType.ToUpper() == productType.ToUpper())
                    {
                        product = temp;
                    }
                }
            }
            return product;
        }
    }
}

        
