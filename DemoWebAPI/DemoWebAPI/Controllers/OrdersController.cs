using DemoWebApi.Data.Interfaces;
using DemoWebApi.Models;
using DemoWebApi.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDataService service;
        public OrdersController(IOrderDataService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Produces(typeof(List<Order>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await service.GetOrders();
                return Ok( orders.Select(order => new OrderViewModel { 
                         Id = order.Id, Total = order.Total,
                          UserId = order.User.Id, UserName = order.User.Name,
                           Items = order.OrderItems.Select( oi => new OrderItemViewModel
                           {
                                Id = oi.Id, Description = oi.Description, OrderId = order.Id
                           }).ToList()
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await service.GetOrderById(id);
                if (order == null) return NotFound();
                return Ok(order);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateOrder([FromBody] Order newOrder)
        {
            if (newOrder == null) return BadRequest();

            try
            {
                await service.CreateOrder(newOrder);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutOrder(int id, [FromBody] Order orderUpdated)
        {
            if (orderUpdated == null  || id != orderUpdated?.Id ) return BadRequest();
            try
            {
                var orderDb = await service.GetOrderById(id);
                if (orderDb == null) return NotFound();
                await service.UpdateOrder(orderUpdated);
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
 
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id < 0) return BadRequest();
            try
            {
                var orderDb = await service.GetOrderById(id);
                if (orderDb == null) return NotFound();
                await service.DeleteOrder(id);
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
