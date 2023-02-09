using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.post
{
    public class PostRes : IPost

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public PostRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddPostAsync(PostModel Post)
        {
            var newPost = _mapper.Map<Post>(Post);
            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return newPost.PostID;
        }

        public async Task<List<PostModel>> GetAllPostAsync()
        {
            var PostList = await _context.Posts.ToListAsync();
            return _mapper.Map<List<PostModel>>(PostList);
        }

        public async Task<PostModel> GetPostAsync(Guid id)
        {
            var resultDetailPost = await _context.Posts.FindAsync(id);
            return _mapper.Map<PostModel>(resultDetailPost);
        }


        public async Task RemovePostAllAsync(List<PostModel> Post)
        {
            foreach (var item in Post)
            {
                RemovePostAsync(item.PostID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemovePostAsync(Guid id)
        {
            if (id != null)
            {
                var getPost = await _context.Posts.FindAsync(id);
                if (getPost != null)
                {
                    _context.Posts.Remove(getPost);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdatePostAsync(Guid id, PostModel Post)
        {

            if (id == Post.PostID)
            {
                var updatePost = _mapper.Map<Post>(Post);
                _context.Posts!.Update(updatePost);
                await _context.SaveChangesAsync();
            }

        }


    }
}
