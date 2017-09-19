using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data
{
    public class TestOrderRepository : IOrderRepository
    {
        private static List<Order> _testOrders = new List<Order>();

        public TestOrderRepository()
        {
            if (!_testOrders.Any())
            {
                _testOrders.AddRange(new List<Order>()
                {
                    new Order
                    {
                        OrderNumber = 1,
                        CustomerName = "TestMe, Inc.",
                        State = "OH",
                        TaxRate = 6.25M,
                        ProductType = "Wood",
                        Area = 200M,
                        CostPerSquareFoot = 5.15M,
                        LaborCostPerSquareFoot = 4.75M,
                        MaterialCost = 515.00M,
                        LaborCost = 475.00M,
                        Tax = 61.88M,
                        Total = 1051.88M,
                        Date = "06012013"
                    },
                    new Order
                    {
                        OrderNumber = 2,
                        CustomerName = "Just Checking",
                        State = "OH",
                        TaxRate = 6.25M,
                        ProductType = "Wood",
                        Area = 200M,
                        CostPerSquareFoot = 5.15M,
                        LaborCostPerSquareFoot = 4.75M,
                        MaterialCost = 515.00M,
                        LaborCost = 475.00M,
                        Tax = 61.88M,
                        Total = 1051.88M,
                        Date = "06012013"
                    },
                    new Order
                    {
                        OrderNumber = 1,
                        CustomerName = "Extra Date Check",
                        State = "OH",
                        TaxRate = 6.25M,
                        ProductType = "Wood",
                        Area = 200M,
                        CostPerSquareFoot = 5.15M,
                        LaborCostPerSquareFoot = 4.75M,
                        MaterialCost = 515.00M,
                        LaborCost = 475.00M,
                        Tax = 61.88M,
                        Total = 1051.88M,
                        Date = "06012018"
                    }
                });
            }
        }

        public List<Order> LoadOrders(string date)
        {
            List<Order> query = _testOrders.Where(s => s.Date == date).OrderBy(a=>a.OrderNumber).ToList();
            return query;
        }

        public void SaveOrder(List<Order> orders, string date)
        {
            List<Order> newList = new List<Order>();
            if (orders == null || orders.Count == 0)
            {
                foreach (var t in _testOrders.ToList())
                {
                    if (t.Date != date)
                    {
                        newList.Add(t);
                    }
                }
                _testOrders.Clear();
                _testOrders = newList;
                return;
            }
            foreach (var t in _testOrders.ToList())
            {
                if (t.Date != date)
                {
                    newList.Add(t);
                }
            }
            newList.AddRange(orders);
            _testOrders.Clear();
            _testOrders = newList;
        }
    }
}
