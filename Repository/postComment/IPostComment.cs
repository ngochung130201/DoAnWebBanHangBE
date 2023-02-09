using DoAnBE.ViewModels;

namespace DoAnBE.Repository.postComment
{
    public interface IPostComment
    {
        public Task<List<PostCommentModel>> GetAllPostCommentAsync();
        public Task<Guid> AddPostCommentAsync(PostCommentModel PostComment);
        public Task<PostCommentModel> GetPostCommentAsync(Guid id);
        public Task UpdatePostCommentAsync(Guid id, PostCommentModel PostComment);
        public Task RemovePostCommentAsync(Guid id);
        public Task RemovePostCommentAllAsync(List<PostCommentModel> PostComment);
    }
}
