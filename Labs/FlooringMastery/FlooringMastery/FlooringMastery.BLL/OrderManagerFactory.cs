using System;
using System.Configuration;
using FlooringMastery.Data;
using FlooringMastery.Data.TestRepos;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(), new TestStateTaxRepository(), new TestProductRepository());
                case "Prod":
                    string orderDirectory = ConfigurationManager.AppSettings["FileOrder"];
                    string statePath = ConfigurationManager.AppSettings["FileState"];
                    string productPath = ConfigurationManager.AppSettings["FileProduct"];
                    return new OrderManager(new FileOrderRepository(orderDirectory), new FileStateTaxRepository(statePath), new FileProductRepository(productPath));
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}