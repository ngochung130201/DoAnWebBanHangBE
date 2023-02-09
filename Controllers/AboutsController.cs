using DoAnBE.Models;
using DoAnBE.Repository.about;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IAbout _AboutRepo;

        public AboutsController(IAbout repo, ComputerdbContext context)

        {
            _context = context;
            _AboutRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            var result = await _AboutRepo.GetAllAboutAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdAbout(int id)
        {
          var About = await _AboutRepo.GetAboutAsync(id);
            return  About == null ? NotFound() : Ok(About);

            
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(AboutModel About)
        {
            try
            {
                var result = await _AboutRepo.AddAboutAsync(About);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            try
            {
                await _AboutRepo.RemoveAboutAsync(id);
                return Ok();
            }
            catch { 
            return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(int id,AboutModel About)
        {
            if (id != About.Id)
            {
                return NotFound();
            }
            await _AboutRepo.UpdateAboutAsync(id, About);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(List<AboutModel> Abouts)
        {
            var listAbout = await _context.Abouts.ToListAsync();
            await _AboutRepo.RemoveAboutAllAsync(Abouts);
            return Ok(Abouts);
        }

    }
}
