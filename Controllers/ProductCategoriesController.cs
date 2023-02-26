using DoAnBE.Helper;
using DoAnBE.Models;
using DoAnBE.Repository.productCategory;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategorysController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IProductCategory _ProductCategoryRepo;

        public ProductCategorysController(IProductCategory repo, ComputerdbContext context)

        {
            _context = context;
            _ProductCategoryRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductCategory()
        {
            var result = await _ProductCategoryRepo.GetAllProductCategoryAsync();
            return Ok(result);

        }
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetIdProductCategory(string slug)
        {
            var ProductCategory = await _ProductCategoryRepo.GetProductCategoryAsync(slug);
            return ProductCategory == null ? NotFound() : Ok(ProductCategory);


        }
        [HttpPost]
        public async Task<IActionResult> AddProductCategory(ProductCategoryModel ProductCategory)
        {
            try
            {
                var listProductCategory = _context.ProductCategories.FirstOrDefault(x=> x.Name.ToLower() == ProductCategory.Name.ToLower());
                if(listProductCategory != null)
                {
                return BadRequest(new {err = "Tên danh mục đã tồn tại"});
                }
                else
                {
                    var result = await _ProductCategoryRepo.AddProductCategoryAsync(ProductCategory);
                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProductCategory(Guid id)
        {
            try
            {
                var getIdProduct = await _context.Products.FirstOrDefaultAsync(x=>x.CateID == id);
               if(getIdProduct != null)
                {
                    return BadRequest();
                }
                else
                {
                    await _ProductCategoryRepo.RemoveProductCategoryAsync(id);
                    return Ok();
                }
                  
                
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{slug}")]
        public async Task<IActionResult> UpdateProductCategory(string slug, ProductCategoryModel ProductCategory)
        {
           
            if (slug != ProductCategory.Slug)
            {
                return NotFound();
            }
            await _ProductCategoryRepo.UpdateProductCategoryAsync(slug, ProductCategory);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProductCategory(List<ProductCategoryModel> ProductCategorys)
        {
            var listProductCategory = await _context.ProductCategories.ToListAsync();
            await _ProductCategoryRepo.RemoveProductCategoryAllAsync(ProductCategorys);
            return Ok(ProductCategorys);
        }

    }
}
