using DoAnBE.Models;
using DoAnBE.Repository.silider;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SilidersController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly ISilider _siliderRepo;
        public SilidersController(ComputerdbContext context, ISilider siliderRepo)
        {
            _context = context;
            _siliderRepo = siliderRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSilider()
        {
            var result = await _siliderRepo.GetAllSliderAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdSilider(int id)
        {
            var Silider = await _siliderRepo.GetSliderAsync(id);
            return Silider == null ? NotFound() : Ok(Silider);


        }
        [HttpPost]
        public async Task<IActionResult> AddSilider(SliderModel Silider)
        {
            try
            {
                var result = await _siliderRepo.AddSliderAsync(Silider);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSilider(int id)
        {
            try
            {
                await _siliderRepo.RemoveSliderAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSilider(int id, SliderModel Silider)
        {
            if (id != Silider.Id)
            {
                return NotFound();
            }
            await _siliderRepo.UpdateSliderAsync(id, Silider);
            return Ok();
        }
      
    }
}
