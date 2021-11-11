using DemoWebApi.Data.Interfaces;
using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Data.Implementations
{
    public class OrderDataService : IOrderDataService
    {
        private readonly ECommerceContext dbContext;

        public OrderDataService(ECommerceContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateOrder(Order newOrder)
        {
            dbContext.Orders.Add(newOrder);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await GetOrderById(id);
            if(order != null)
            {
                dbContext.Orders.Remove(order);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await dbContext.Orders
                .Include(ordine => ordine.OrderItems)
                .Include(ordine => ordine.User).ThenInclude(x => x.Roles)
                .ToListAsync();
        }

        public async Task UpdateOrder(Order orderUpdated)
        {
            var orderDb = await GetOrderById(orderUpdated.Id);
            if(orderDb != null)
            {
                dbContext.Entry(orderDb).State = EntityState.Detached;
                dbContext.Entry(orderUpdated).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
