using DoAnBE.ViewModels;

namespace DoAnBE.Repository.menu
{
    public interface IMenu
    {
        public Task<List<MenuModel>> GetAllMenuAsync();
        public Task<int> AddMenuAsync(MenuModel menu);
        public Task<MenuModel> GetMenuAsync(int id);
        public Task UpdateMenuAsync(int id, MenuModel menu);
        public Task RemoveMenuAsync(int id);
        public Task RemoveMenuAllAsync(List<MenuModel> menu);

    }
}
