using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApi.Data
{
    public class ECommerceContext: DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> opzioni) 
            : base(opzioni){}

        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
