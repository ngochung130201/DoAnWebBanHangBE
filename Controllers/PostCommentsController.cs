using DoAnBE.Models;
using DoAnBE.Repository.postComment;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IPostComment _PostCommentRepo;

        public PostCommentsController(IPostComment repo, ComputerdbContext context)

        {
            _context = context;
            _PostCommentRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPostComment()
        {
            var result = await _PostCommentRepo.GetAllPostCommentAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdPostComment(Guid id)
        {
            var PostComment = await _PostCommentRepo.GetPostCommentAsync(id);
            return PostComment == null ? NotFound() : Ok(PostComment);


        }
        [HttpPost]
        public async Task<IActionResult> AddPostComment(PostCommentModel PostComment)
        {
            try
            {
                var result = await _PostCommentRepo.AddPostCommentAsync(PostComment);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePostComment(Guid id)
        {
            try
            {
                await _PostCommentRepo.RemovePostCommentAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostComment(Guid id, PostCommentModel PostComment)
        {
            if (id != PostComment.PostID)
            {
                return NotFound();
            }
            await _PostCommentRepo.UpdatePostCommentAsync(id, PostComment);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePostComment(List<PostCommentModel> PostComments)
        {
            var listPostComment = await _context.PostComments.ToListAsync();
            await _PostCommentRepo.RemovePostCommentAllAsync(PostComments);
            return Ok(PostComments);
        }

    }
}
