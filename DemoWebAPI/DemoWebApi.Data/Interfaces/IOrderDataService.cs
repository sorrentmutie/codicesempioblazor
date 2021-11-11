using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Data.Interfaces
{
    public interface IOrderDataService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task CreateOrder(Order newOrder);
        Task UpdateOrder(Order orderUpdated);
        Task DeleteOrder(int id);
    }
}
