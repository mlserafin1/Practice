using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [TestCase("06012013", true)]
        [TestCase("06032013", false)]
        public void CanLoadOrder(string date, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrders(date);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Success, expectedResult);
        }

        [TestCase("06012012", "Any Name", "MI", "Wood", 200, false)]
        [TestCase("06012018", "", "MI", "Wood", 200, false)]
        [TestCase("06012018", "Any Name", "DE", "Wood", 200, false)]
        [TestCase("06012018", "Any Name", "MI", "Steel", 200, false)]
        [TestCase("06012018", "Any Name", "MI", "Wood", 50, false)]
        [TestCase("06012018", "Any Name", "MI", "Wood", 200, true)]
        [TestCase("06012018", "Any Name", "MI", "wood", 200, true)]
        [TestCase("06012018", "Any Name", "Michigan", "Wood", 200, true)]
        [TestCase("06012018", "Any Name", "michigan", "Wood", 200, true)]
        public void CreateOrderTest(string date, string name, string state, string productType, decimal area, bool expectedResult)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderResponse response = manager.CreateOrder(date, name, state, productType, area);


            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("06012013", 2)]
        [TestCase("06022013", 1)]
        [TestCase("06032013", 0)]
        public void CheckOrderDateCount(string date, int count)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrders(date);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Orders.Count, count);
        }
    }
}
