using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.menu
{
    public class MenuRes : IMenu
            
    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public MenuRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> AddMenuAsync(MenuModel menu)
        {
            var newMenu = _mapper.Map<Menu>(menu);
            _context.Menus.Add(newMenu);
            await _context.SaveChangesAsync();
            return newMenu.Id;
        }

        public async Task<List<MenuModel>> GetAllMenuAsync()
        {
            var menuList = await _context.Menus.ToListAsync();
            return _mapper.Map<List<MenuModel>>(menuList);
        }

        public async Task<MenuModel> GetMenuAsync(int id)
        {
            var resultDetailMenu = await _context.Menus.FindAsync(id);
            return _mapper.Map<MenuModel>(resultDetailMenu);
        }

      
        public  async Task RemoveMenuAllAsync(List<MenuModel> menu)
        {
           foreach(var item in menu)
            {
                RemoveMenuAsync(item.Id);
            await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveMenuAsync(int id)
        {
            if (id != null)
            {
                var getMenu = await _context.Menus.FindAsync(id);
                if (getMenu != null)
                {
                    _context.Menus.Remove(getMenu);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateMenuAsync(int id, MenuModel menu)
        {

            if (id == menu.Id)
            {
                var updateMenu = _mapper.Map<Menu>(menu);
                _context.Menus!.Update(updateMenu);
                await _context.SaveChangesAsync();
            }

        }


    }
}
