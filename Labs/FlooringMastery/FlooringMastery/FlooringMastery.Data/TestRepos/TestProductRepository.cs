using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.TestRepos
{
    public class TestProductRepository : IProductRepository
    {
        private static List<Product> _testProducts = new List<Product>();

        public TestProductRepository()
        {
            if (!_testProducts.Any())
            {
                _testProducts.AddRange(new List<Product>()
                {
                    new Product
                    {
                        productType = "Carpet",
                        costPerSquareFoot = 2.25M,
                        laborCostPerSquareFoot = 2.10M
                    },
                    new Product
                    {
                        productType = "Laminate",
                        costPerSquareFoot = 1.75M,
                        laborCostPerSquareFoot = 2.10M
                    },
                    new Product
                    {
                        productType = "Tile",
                        costPerSquareFoot = 3.50M,
                        laborCostPerSquareFoot = 4.15M
                    },
                    new Product
                    {
                        productType = "Wood",
                        costPerSquareFoot = 5.15M,
                        laborCostPerSquareFoot = 4.75M
                    }
                });
            }
        }

        public List<Product> GetAll()
        {
            return _testProducts;
        }

        public Product GetByName(string product)
        {
            Product newProduct = new Product();
            string temp = product.ToUpper();
            newProduct = null;
            foreach (var pro in _testProducts)
            {
                if (temp == pro.productType.ToUpper())
                {
                    newProduct = pro;
                    return newProduct;
                }
            }
            return newProduct;
        }
    }
}
