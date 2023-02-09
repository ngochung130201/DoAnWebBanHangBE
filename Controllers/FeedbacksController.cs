using DoAnBE.Models;
using DoAnBE.Repository.feedback;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IFeedback _FeedbackRepo;

        public FeedbacksController(IFeedback repo, ComputerdbContext context)

        {
            _context = context;
            _FeedbackRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            var result = await _FeedbackRepo.GetAllFeedbackAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdFeedback(int id)
        {
            var Feedback = await _FeedbackRepo.GetFeedbackAsync(id);
            return Feedback == null ? NotFound() : Ok(Feedback);


        }
        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackModel Feedback)
        {
            try
            {
                var result = await _FeedbackRepo.AddFeedbackAsync(Feedback);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeedback(int id)
        {
            try
            {
                await _FeedbackRepo.RemoveFeedbackAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, FeedbackModel Feedback)
        {
            if (id != Feedback.Id)
            {
                return NotFound();
            }
            await _FeedbackRepo.UpdateFeedbackAsync(id, Feedback);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFeedback(List<FeedbackModel> Feedbacks)
        {
            var listFeedback = await _context.Feedbacks.ToListAsync();
            await _FeedbackRepo.RemoveFeedbackAllAsync(Feedbacks);
            return Ok(Feedbacks);
        }

    }
}
