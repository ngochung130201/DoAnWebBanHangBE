using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.feedback
{
    public class FeedbackRes : IFeedback

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public FeedbackRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> AddFeedbackAsync(FeedbackModel Feedback)
        {
            var newFeedback = _mapper.Map<Feedback>(Feedback);
            _context.Feedbacks.Add(newFeedback);
            await _context.SaveChangesAsync();
            return newFeedback.Id;
        }

        public async Task<List<FeedbackModel>> GetAllFeedbackAsync()
        {
            var FeedbackList = await _context.Feedbacks.ToListAsync();
            return _mapper.Map<List<FeedbackModel>>(FeedbackList);
        }

        public async Task<FeedbackModel> GetFeedbackAsync(int id)
        {
            var resultDetailFeedback = await _context.Feedbacks.FindAsync(id);
            return _mapper.Map<FeedbackModel>(resultDetailFeedback);
        }


        public async Task RemoveFeedbackAllAsync(List<FeedbackModel> Feedback)
        {
            foreach (var item in Feedback)
            {
                RemoveFeedbackAsync(item.Id);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFeedbackAsync(int id)
        {
            if (id != null)
            {
                var getFeedback = await _context.Feedbacks.FindAsync(id);
                if (getFeedback != null)
                {
                    _context.Feedbacks.Remove(getFeedback);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateFeedbackAsync(int id, FeedbackModel Feedback)
        {

            if (id == Feedback.Id)
            {
                var updateFeedback = _mapper.Map<Feedback>(Feedback);
                _context.Feedbacks!.Update(updateFeedback);
                await _context.SaveChangesAsync();
            }

        }


    }
}
