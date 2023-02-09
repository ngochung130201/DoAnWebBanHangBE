using DoAnBE.ViewModels;

namespace DoAnBE.Repository.productComment
{
    public interface IProductComment
    {
          public Task<List<ProductCommentModel>> GetAllProductCommentAsync();
        public Task<Guid> AddProductCommentAsync(ProductCommentModel ProductComment);
        public Task<ProductCommentModel> GetProductCommentAsync(Guid id);
        public Task UpdateProductCommentAsync(Guid id, ProductCommentModel ProductComment);
        public Task RemoveProductCommentAsync(Guid id);
        public Task RemoveProductCommentAllAsync(List<ProductCommentModel> ProductComment);
    }
}
