using DoAnBE.ViewModels;

namespace DoAnBE.Repository.about
{
    public interface IAbout
    {
        public Task<List<AboutModel>> GetAllAboutAsync();
        public Task<int> AddAboutAsync(AboutModel About);
        public Task<AboutModel> GetAboutAsync(int id);
        public Task UpdateAboutAsync(int id, AboutModel About);
        public Task RemoveAboutAsync(int id);
        public Task RemoveAboutAllAsync(List<AboutModel> About);
    }
}
