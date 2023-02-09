using DoAnBE.ViewModels;

namespace DoAnBE.Repository.post
{
    public interface IPost
    {
        public Task<List<PostModel>> GetAllPostAsync();
        public Task<Guid> AddPostAsync(PostModel Post);
        public Task<PostModel> GetPostAsync(Guid id);
        public Task UpdatePostAsync(Guid id, PostModel Post);
        public Task RemovePostAsync(Guid id);
        public Task RemovePostAllAsync(List<PostModel> Post);
    }
}
