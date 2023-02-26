using DoAnBE.Models;
using DoAnBE.Repository.brand;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IBrand _BrandRepo;

        public BrandsController(IBrand repo, ComputerdbContext context)

        {
            _context = context;
            _BrandRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var result = await _BrandRepo.GetBrandAllAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdBrand(int id)
        {
            var Brand = await _BrandRepo.GetBrandAsync(id);
            return Brand == null ? NotFound() : Ok(Brand);


        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandModel Brand)
        {
            try
            {
                var brand = _context.Brands.SingleOrDefault(x=>x.Name.ToUpper() == Brand.Name.ToUpper());
                if(brand !=null)
                {
                    return BadRequest("Thương hiệu đã tồn tại !");
                }
                var result = await _BrandRepo.CraeteBrandAsync(Brand);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            try
            {
                await _BrandRepo.DeleteBrandAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandModel Brand)
        {
            if (id != Brand.BrandID)
            {
                return NotFound();
            }
            var brand = _context.Brands.SingleOrDefault(x => x.Name.ToUpper() == Brand.Name.ToUpper());
            if (brand != null)
            {
                return BadRequest("Thương hiệu đã tồn tại !");
            }
            await _BrandRepo.UpdateBrandAsync(id, Brand);
            return Ok();
        }


    }
}
