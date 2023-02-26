using DoAnBE.Models;
using DoAnBE.Repository.order;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IOrder _OrderRepo;

        public OrdersController(IOrder repo, ComputerdbContext context)

        {
            _context = context;
            _OrderRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var result = await _OrderRepo.GetAllOrderAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdOrder(Guid id)
        {
            var Order = await _OrderRepo.GetOrderAsync(id);
            return Order == null ? NotFound() : Ok(Order);


        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderModel Order)
        {
            try
            {
                var result = await _OrderRepo.AddOrderAsync(Order);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(Guid id)
        {
            try
            {
                await _OrderRepo.RemoveOrderAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderModel Order)
        {
            if (id != Order.OrderID)
            {
                return NotFound();
            }
            await _OrderRepo.UpdateOrderAsync(id, Order);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrder(List<OrderModel> Orders)
        {
            var listOrder = await _context.Orders.ToListAsync();
            await _OrderRepo.RemoveOrderAllAsync(Orders);
            return Ok(Orders);
        }

    }
}
