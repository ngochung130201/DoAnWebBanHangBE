using DoAnBE.Models;
using DoAnBE.Repository.product;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IProduct _ProductRepo;

        public ProductsController(IProduct repo, ComputerdbContext context)

        {
            _context = context;
            _ProductRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _ProductRepo.GetAllProductAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdProduct(Guid id)
        {
            var Product = await _ProductRepo.GetProductAsync(id);
            return Product == null ? NotFound() : Ok(Product);


        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel Product)
        {
            try
            {
                var result = await _ProductRepo.AddProductAsync(Product);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            try
            {
                await _ProductRepo.RemoveProductAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductModel Product)
        {
            if (id != Product.ProductID)
            {
                return NotFound();
            }
            await _ProductRepo.UpdateProductAsync(id, Product);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(List<ProductModel> Products)
        {
            var listProduct = await _context.Products.ToListAsync();
            await _ProductRepo.RemoveProductAllAsync(Products);
            return Ok(Products);
        }

    }
}
