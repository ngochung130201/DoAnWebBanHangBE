using DoAnBE.ViewModels;

namespace DoAnBE.Repository.silider
{
    public interface ISilider
    {
        public Task<List<SliderModel>> GetAllSliderAsync();
        public Task<int> AddSliderAsync(SliderModel Slider);
        public Task<SliderModel> GetSliderAsync(int id);
        public Task UpdateSliderAsync(int id, SliderModel Slider);
        public Task RemoveSliderAsync(int id);
        public Task RemoveSliderAllAsync(List<SliderModel> Slider);
    }
}
