using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal Total { get;  set; }
        public List<OrderItemViewModel> Items { get; set; }
    }

    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
    }

}
