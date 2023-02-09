using DoAnBE.ViewModels;

namespace DoAnBE.Repository.brand
{
    public interface IBrand
    {
        public Task<List<BrandModel>> GetBrandAllAsync();
        public Task<BrandModel> GetBrandAsync(int id);
        public Task<int> CraeteBrandAsync(BrandModel brandModel);
        public Task UpdateBrandAsync(int id,BrandModel brandModel);
        public Task DeleteBrandAsync(int id);
    }
}
