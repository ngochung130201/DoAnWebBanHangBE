using DoAnBE.Models;
using DoAnBE.Repository.customer;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly ICustomer _CustomerRepo;

        public CustomersController(ICustomer repo, ComputerdbContext context)

        {
            _context = context;
            _CustomerRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _CustomerRepo.GetAllCustomerAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdCustomer(Guid id)
        {
            var Customer = await _CustomerRepo.GetCustomerAsync(id);
            return Customer == null ? NotFound() : Ok(Customer);


        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerModel Customer)
        {
            try
            {
                var result = await _CustomerRepo.AddCustomerAsync(Customer);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomer(Guid id)
        {
            try
            {
                await _CustomerRepo.RemoveCustomerAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerModel Customer)
        {
            if (id != Customer.ID)
            {
                return NotFound();
            }
            await _CustomerRepo.UpdateCustomerAsync(id, Customer);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCustomer(List<CustomerModel> Customers)
        {
            var listCustomer = await _context.Customers.ToListAsync();
            await _CustomerRepo.RemoveCustomerAllAsync(Customers);
            return Ok(Customers);
        }

    }
}
