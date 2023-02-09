using DoAnBE.Models;
using DoAnBE.Repository.menu;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IMenu _menuRepo;

        public MenusController(IMenu repo, ComputerdbContext context)

        {
            _context = context;
            _menuRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            var result = await _menuRepo.GetAllMenuAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdMenu(int id)
        {
          var menu = await _menuRepo.GetMenuAsync(id);
            return  menu == null ? NotFound() : Ok(menu);

            
        }
        [HttpPost]
        public async Task<IActionResult> AddMenu(MenuModel menu)
        {
            try
            {
                var result = await _menuRepo.AddMenuAsync(menu);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMenu(int id)
        {
            try
            {
                await _menuRepo.RemoveMenuAsync(id);
                return Ok();
            }
            catch { 
            return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id,MenuModel menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }
            await _menuRepo.UpdateMenuAsync(id, menu);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveMenu(List<MenuModel> menus)
        {
            var listMenu = await _context.Menus.ToListAsync();
            await _menuRepo.RemoveMenuAllAsync(menus);
            return Ok(menus);
        }

    }
}
