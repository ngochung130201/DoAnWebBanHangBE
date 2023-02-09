using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.postComment
{
    public class PostCommentRes : IPostComment

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public PostCommentRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddPostCommentAsync(PostCommentModel PostComment)
        {
            var newPostComment = _mapper.Map<PostComment>(PostComment);
            _context.PostComments.Add(newPostComment);
            await _context.SaveChangesAsync();
            return newPostComment.PostID;
        }

        public async Task<List<PostCommentModel>> GetAllPostCommentAsync()
        {
            var PostCommentList = await _context.PostComments.ToListAsync();
            return _mapper.Map<List<PostCommentModel>>(PostCommentList);
        }

        public async Task<PostCommentModel> GetPostCommentAsync(Guid id)
        {
            var resultDetailPostComment = await _context.PostComments.FindAsync(id);
            return _mapper.Map<PostCommentModel>(resultDetailPostComment);
        }


        public async Task RemovePostCommentAllAsync(List<PostCommentModel> PostComment)
        {
            foreach (var item in PostComment)
            {
                RemovePostCommentAsync(item.PostID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemovePostCommentAsync(Guid id)
        {
            if (id != null)
            {
                var getPostComment = await _context.PostComments.FindAsync(id);
                if (getPostComment != null)
                {
                    _context.PostComments.Remove(getPostComment);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdatePostCommentAsync(Guid id, PostCommentModel PostComment)
        {

            if (id == PostComment.PostID)
            {
                var updatePostComment = _mapper.Map<PostComment>(PostComment);
                _context.PostComments!.Update(updatePostComment);
                await _context.SaveChangesAsync();
            }

        }


    }
}
