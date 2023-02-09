using DoAnBE.Models;
using DoAnBE.Repository.supplier;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly ISupplier _SupplierRepo;

        public SuppliersController(ISupplier repo, ComputerdbContext context)

        {
            _context = context;
            _SupplierRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var result = await _SupplierRepo.GetAllSupplierAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdSupplier(Guid id)
        {
            var Supplier = await _SupplierRepo.GetSupplierAsync(id);
            return Supplier == null ? NotFound() : Ok(Supplier);


        }
        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierModel Supplier)
        {
            try
            {
                var result = await _SupplierRepo.AddSupplierAsync(Supplier);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSupplier(Guid id)
        {
            try
            {
                await _SupplierRepo.RemoveSupplierAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(Guid id, SupplierModel Supplier)
        {
            if (id != Supplier.SupplierID)
            {
                return NotFound();
            }
            await _SupplierRepo.UpdateSupplierAsync(id, Supplier);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSupplier(List<SupplierModel> Suppliers)
        {
            var listSupplier = await _context.Suppliers.ToListAsync();
            await _SupplierRepo.RemoveSupplierAllAsync(Suppliers);
            return Ok(Suppliers);
        }

    }
}
