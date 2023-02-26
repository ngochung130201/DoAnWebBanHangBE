using DoAnBE.Models;
using DoAnBE.ViewModels;

namespace DoAnBE.Repository.product
{
    public interface IProduct
    {
        public Task<List<ProductModel>> GetAllProductAsync();
        public Task<Guid> AddProductAsync(ProductModel Product);
        public Task<ProductModel> GetProductAsync(Guid id);
        public Task UpdateProductAsync(Guid id, ProductModel Product);
        public Task RemoveProductAsync(Guid id);
        public Task RemoveProductAllAsync(List<ProductModel> Product);
    }
}
