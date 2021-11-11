using System;
using System.Collections.Generic;

namespace DemoWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string Description { get; set; }
        public Address Address {get;set;}
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public int UserId { get; set; }
        public User User { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }


    public class Address
    {
        public int Id { get; set; }
        public string Indirizzo { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

}
