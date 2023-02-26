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
        private readonly IWebHostEnvironment _environment;
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
        public async Task<IActionResult> AddSilider( SliderModel Silider)
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
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] SliderModel Silider)
        {
            var newSlider = new Slider
            {
                Id = Silider.Id,
            
                Name= Silider.Name, 
                Link= Silider.Link,
                IsStatus= Silider.IsStatus,
            };
            if(Silider.fileImages?.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Silider.fileImages.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await Silider.fileImages.CopyToAsync(stream);
                };
                newSlider.Image = "/images/" + Silider.fileImages.FileName;

            }
            else
            {
                newSlider.Image = "/images/" + "";
            }
            return Ok(newSlider);
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
        [HttpPost]
        [Route("upload-di-ngu")]
        public async Task<IActionResult> AddSliderAsync([FromForm] SliderModel Slider)
        {
            //var newSlider = _mapper.Map<Slider>(Slider);
            var newSlider = new Slider
            {
                IsStatus = Slider.IsStatus,
                Link = Slider.Link,
                Name = Slider.Name,

            };
            if (Slider.fileImages?.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", Slider.fileImages.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await Slider.fileImages.CopyToAsync(stream);
                };
                newSlider.Image = "/images/" + Slider.fileImages.FileName;
            }

            _context.Sliders.Add(newSlider);
            await _context.SaveChangesAsync();
            return Ok(newSlider);
        }
    }
}
