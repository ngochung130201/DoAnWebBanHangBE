using DoAnBE.ViewModels;

namespace DoAnBE.Repository.postCategory
{
    public interface IPostCategory
    {
        public Task<List<PostCategoryModel>> GetAllPostCategoryAsync();
        public Task<Guid> AddPostCategoryAsync(PostCategoryModel PostCategory);
        public Task<PostCategoryModel> GetPostCategoryAsync(string slug);
        public Task UpdatePostCategoryAsync(Guid id, PostCategoryModel PostCategory);
        public Task RemovePostCategoryAsync(Guid id);
        public Task RemovePostCategoryAllAsync(List<PostCategoryModel> PostCategory);
    }
}
