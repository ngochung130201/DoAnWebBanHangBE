using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.brand
{
    public class BrandRes : IBrand
    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;

        public BrandRes(ComputerdbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> CraeteBrandAsync(BrandModel brandModel)
        {
           
            var newBrand = _mapper.Map<Brand>(brandModel);
            _context.Brands.Add(newBrand);
            await _context.SaveChangesAsync();
            return newBrand.BrandID;

        }

        public async Task DeleteBrandAsync(int id)
        {
           var brand = await _context.Brands.SingleOrDefaultAsync(x=>x.BrandID == id);
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

        }

        public async Task<List<BrandModel>> GetBrandAllAsync()
        {
            var getAllBrand = await _context.Brands.ToListAsync();
            return _mapper.Map<List<BrandModel>>(getAllBrand);
        }

        public async Task<BrandModel> GetBrandAsync(int id)
        {
          
                var getBrand = await _context.Brands.FindAsync(id);
                return _mapper.Map<BrandModel>(getBrand);
                
            
        }

        public  async Task UpdateBrandAsync(int id, BrandModel brandModel)
        {

            if (id == brandModel.BrandID)
            {
                var updateBrand = _mapper.Map<Brand>(brandModel);
                _context.Brands!.Update(updateBrand);
                await _context.SaveChangesAsync();
            }

        }
    }
}
