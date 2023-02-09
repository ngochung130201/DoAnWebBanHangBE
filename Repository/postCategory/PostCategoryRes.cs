using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.postCategory
{
    public class PostCategoryRes : IPostCategory

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public PostCategoryRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddPostCategoryAsync(PostCategoryModel PostCategory)
        {
            var newPostCategory = _mapper.Map<PostCategory>(PostCategory);
            _context.PostCategories.Add(newPostCategory);
            await _context.SaveChangesAsync();
            return newPostCategory.PostID;
        }

        public async Task<List<PostCategoryModel>> GetAllPostCategoryAsync()
        {
            var PostCategoryList = await _context.PostCategories.ToListAsync();
            return _mapper.Map<List<PostCategoryModel>>(PostCategoryList);
        }

        public async Task<PostCategoryModel> GetPostCategoryAsync(string slug)
        {
            var resultDetailPostCategory = await _context.PostCategories.FindAsync(slug);
            return _mapper.Map<PostCategoryModel>(resultDetailPostCategory);
        }


        public async Task RemovePostCategoryAllAsync(List<PostCategoryModel> PostCategory)
        {
            foreach (var item in PostCategory)
            {
                RemovePostCategoryAsync(item.PostID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemovePostCategoryAsync(Guid id)
        {
            if (id != null)
            {
                var getPostCategory = await _context.PostCategories.FindAsync(id);
                if (getPostCategory != null)
                {
                    _context.PostCategories.Remove(getPostCategory);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdatePostCategoryAsync(Guid id, PostCategoryModel PostCategory)
        {

            if (id == PostCategory.PostID)
            {
                var updatePostCategory = _mapper.Map<PostCategory>(PostCategory);
                _context.PostCategories!.Update(updatePostCategory);
                await _context.SaveChangesAsync();
            }

        }


    }
}
