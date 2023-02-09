using DoAnBE.Models;
using DoAnBE.Repository.post;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IPost _PostRepo;

        public PostsController(IPost repo, ComputerdbContext context)

        {
            _context = context;
            _PostRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var result = await _PostRepo.GetAllPostAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdPost(Guid id)
        {
            var Post = await _PostRepo.GetPostAsync(id);
            return Post == null ? NotFound() : Ok(Post);


        }
        [HttpPost]
        public async Task<IActionResult> AddPost(PostModel Post)
        {
            try
            {
                var result = await _PostRepo.AddPostAsync(Post);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePost(Guid id)
        {
            try
            {
                await _PostRepo.RemovePostAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, PostModel Post)
        {
            if (id != Post.PostID)
            {
                return NotFound();
            }
            await _PostRepo.UpdatePostAsync(id, Post);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePost(List<PostModel> Posts)
        {
            var listPost = await _context.Posts.ToListAsync();
            await _PostRepo.RemovePostAllAsync(Posts);
            return Ok(Posts);
        }

    }
}
