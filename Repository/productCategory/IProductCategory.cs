using DoAnBE.ViewModels;

namespace DoAnBE.Repository.productCategory
{
    public interface IProductCategory
    {
        public Task<List<ProductCategoryModel>> GetAllProductCategoryAsync();
        public Task<Guid> AddProductCategoryAsync(ProductCategoryModel ProductCategory);
        public Task<ProductCategoryModel> GetProductCategoryAsync(string slug);
        public Task UpdateProductCategoryAsync(string slug, ProductCategoryModel ProductCategory);
        public Task RemoveProductCategoryAsync(Guid id);
        public Task RemoveProductCategoryAllAsync(List<ProductCategoryModel> ProductCategory);
    }
}
