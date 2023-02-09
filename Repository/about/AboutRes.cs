using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.about
{
    public class AboutRes : IAbout
    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public AboutRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> AddAboutAsync(AboutModel About)
        {
            var newAbout = _mapper.Map<About>(About);
            _context.Abouts.Add(newAbout);
            await _context.SaveChangesAsync();
            return newAbout.Id;
        }

        public async Task<List<AboutModel>> GetAllAboutAsync()
        {
            var AboutList = await _context.Abouts.ToListAsync();
            return _mapper.Map<List<AboutModel>>(AboutList);
        }

        public async Task<AboutModel> GetAboutAsync(int id)
        {
            var resultDetailAbout = await _context.Abouts.FindAsync(id);
            return _mapper.Map<AboutModel>(resultDetailAbout);
        }


        public async Task RemoveAboutAllAsync(List<AboutModel> About)
        {
            foreach (var item in About)
            {
                RemoveAboutAsync(item.Id);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAboutAsync(int id)
        {
            if (id != null)
            {
                var getAbout = await _context.Abouts.FindAsync(id);
                if (getAbout != null)
                {
                    _context.Abouts.Remove(getAbout);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateAboutAsync(int id, AboutModel About)
        {

            if (id == About.Id)
            {
                var updateAbout = _mapper.Map<About>(About);
                _context.Abouts!.Update(updateAbout);
                await _context.SaveChangesAsync();
            }

        }
    }
}
