using DoAnBE.Models;
using DoAnBE.Repository.postCategory;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategorysController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IPostCategory _PostCategoryRepo;

        public PostCategorysController(IPostCategory repo, ComputerdbContext context)

        {
            _context = context;
            _PostCategoryRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPostCategory()
        {
            var result = await _PostCategoryRepo.GetAllPostCategoryAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdPostCategory(string slug)
        {
            var PostCategory = await _PostCategoryRepo.GetPostCategoryAsync(slug);
            return PostCategory == null ? NotFound() : Ok(PostCategory);


        }
        [HttpPost]
        public async Task<IActionResult> AddPostCategory(PostCategoryModel PostCategory)
        {
            try
            {
                var result = await _PostCategoryRepo.AddPostCategoryAsync(PostCategory);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePostCategory(Guid id)
        {
            try
            {
                await _PostCategoryRepo.RemovePostCategoryAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostCategory(Guid id, PostCategoryModel PostCategory)
        {
            if (id != PostCategory.PostID)
            {
                return NotFound();
            }
            await _PostCategoryRepo.UpdatePostCategoryAsync(id, PostCategory);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePostCategory(List<PostCategoryModel> PostCategorys)
        {
            var listPostCategory = await _context.PostCategories.ToListAsync();
            await _PostCategoryRepo.RemovePostCategoryAllAsync(PostCategorys);
            return Ok(PostCategorys);
        }

    }
}
