using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private ITaxRepository _taxRepository;
        private IProductRepository _productRepository;

        public OrderManager(IOrderRepository orderRepo, ITaxRepository taxRepo, IProductRepository productRepo)
        {
            _orderRepository = orderRepo;
            _taxRepository = taxRepo;
            _productRepository = productRepo;
        }

        public OrderLookupResponse LookupOrders(string date)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Orders = _orderRepository.LoadOrders(date);
            if (response.Orders == null || response.Orders.Count == 0)
            {
                response.Success = false;
                response.Message = "There are no orders for the date you entered.";
                return response;
            }
            else
            {
                response.Success = true;
                return response;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = _productRepository.GetAll();
            return products;
        }

        public OrderResponse CreateOrder(string date, string name, string state, string productType, decimal area)
        {
            OrderResponse response = new OrderResponse();
            List<Order> orders = _orderRepository.LoadOrders(date);
            StateTax tax = _taxRepository.GetByName(state);
            Product product = _productRepository.GetByName(productType);
            AddRules rule = new AddRules();
            response = rule.ValidateInput(date, name, tax, product, area);
            if (orders == null || orders.Count == 0)
            {
                response.Order.OrderNumber = 1;
            }
            else
            {
                response.Order.OrderNumber = orders.Max(a => a.OrderNumber) + 1;
            }

            return response;

        }

        public void SaveNewOrder(List<Order> orders)
        {
            _orderRepository.SaveOrder(orders, orders[0].Date);
        }

        public OrderResponse GetSingleOrder (string date, int orderNumber)
        {
            OrderResponse order = new OrderResponse();
            order.Order = null;
            OrderLookupResponse response = new OrderLookupResponse();
            response.Orders = _orderRepository.LoadOrders(date);
            if (response.Orders == null)
            {
                order.Success = false;
                order.Message = "There are no orders for the date you entered.";
                return order;
            }
            else
            {
                foreach (var ord in response.Orders)
                {
                    if (ord.OrderNumber == orderNumber)
                    {
                        order.Order = ord;
                        order.Success = true;
                        return order;
                    }
                }
                if (order.Order == null)
                {
                    order.Success = false;
                    order.Message = $"Order number {orderNumber} does not exist for the date you entered.";
                    return order;
                }
                return order;
            }
           
        }

        public void DeleteOrder(Order order)
        {
            List<Order> fullList = _orderRepository.LoadOrders(order.Date);
            List<Order> newList = new List<Order>();

            foreach (var ord in fullList)
            {
                if (ord.OrderNumber != order.OrderNumber)
                {
                    newList.Add(ord);
                }
            }
            _orderRepository.SaveOrder(newList, order.Date);
        }

        public OrderResponse CreateEditedOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            
            StateTax tax = _taxRepository.GetByName(order.State);
            Product product = _productRepository.GetByName(order.ProductType);
            EditRules rule = new EditRules();
            response = rule.ValidateInput(order.Date, order.CustomerName, tax, product, order.Area);

            return response;

        }

        public void SaveEditedOrder(Order order, string date)
        {
            List<Order> oldOrders = _orderRepository.LoadOrders(date);
            List<Order> newList = new List<Order>();
            
            foreach (var o in oldOrders)
            {
                if (order.OrderNumber == o.OrderNumber)
                {
                    newList.Add(order);
                }
                else
                {
                    newList.Add(o);
                }
            }
            _orderRepository.SaveOrder(newList, date);
        }

        public OrderResponse EditFraudCheck(DateTime date)
        {
            OrderResponse response = new OrderResponse();
            if (date < DateTime.Now)
            {
                response.Success = false;
                response.Message =
                    "To prevent fraud, you cannot edit past orders. Please enter an order date in the future.";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
