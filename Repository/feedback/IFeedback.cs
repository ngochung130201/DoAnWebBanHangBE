using DoAnBE.ViewModels;

namespace DoAnBE.Repository.feedback
{
    public interface IFeedback
    {
        public Task<List<FeedbackModel>> GetAllFeedbackAsync();
        public Task<int> AddFeedbackAsync(FeedbackModel Feedback);
        public Task<FeedbackModel> GetFeedbackAsync(int id);
        public Task UpdateFeedbackAsync(int id, FeedbackModel Feedback);
        public Task RemoveFeedbackAsync(int id);
        public Task RemoveFeedbackAllAsync(List<FeedbackModel> Feedback);
    }
}
