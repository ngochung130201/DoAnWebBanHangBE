using DoAnBE.Models;
using DoAnBE.Repository.orderDetail;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IOrderDetail _OrderDetailRepo;

        public OrderDetailsController(IOrderDetail repo, ComputerdbContext context)

        {
            _context = context;
            _OrderDetailRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            var result = await _OrderDetailRepo.GetAllOrderDetailAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdOrderDetail(Guid id)
        {
            var OrderDetail = await _OrderDetailRepo.GetOrderDetailAsync(id);
            return OrderDetail == null ? NotFound() : Ok(OrderDetail);


        }
        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetailModel OrderDetail)
        {
            try
            {
                var result = await _OrderDetailRepo.AddOrderDetailAsync(OrderDetail);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderDetail(Guid id)
        {
            try
            {
                await _OrderDetailRepo.RemoveOrderDetailAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(Guid id, OrderDetailModel OrderDetail)
        {
            if (id != OrderDetail.OrderDetailId)
            {
                return NotFound();
            }
            await _OrderDetailRepo.UpdateOrderDetailAsync(id, OrderDetail);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(List<OrderDetailModel> OrderDetails)
        {
            var listOrderDetail = await _context.OrderDetails.ToListAsync();
            await _OrderDetailRepo.RemoveOrderDetailAllAsync(OrderDetails);
            return Ok(OrderDetails);
        }

    }
}
