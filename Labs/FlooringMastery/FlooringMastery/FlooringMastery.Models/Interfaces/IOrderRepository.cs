using System.Collections.Generic;
using System.Collections.Specialized;

namespace FlooringMastery.Models
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string date);
        void SaveOrder(List<Order> orders, string date);
    }
}