using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.product
{
    public class ProductRes : IProduct

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public ProductRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddProductAsync(ProductModel Product)
        {
            var newProduct = _mapper.Map<Product>(Product);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.ProductID;
        }

        public async Task<List<ProductModel>> GetAllProductAsync()
        {
            var ProductList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductModel>>(ProductList);
        }

        public async Task<ProductModel> GetProductAsync(Guid id)
        {
            var resultDetailProduct = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductModel>(resultDetailProduct);
        }


        public async Task RemoveProductAllAsync(List<ProductModel> Product)
        {
            foreach (var item in Product)
            {
                RemoveProductAsync(item.ProductID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProductAsync(Guid id)
        {
            if (id != null)
            {
                var getProduct = await _context.Products.FindAsync(id);
                if (getProduct != null)
                {
                    _context.Products.Remove(getProduct);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateProductAsync(Guid id, ProductModel Product)
        {

            if (id == Product.ProductID)
            {
                var updateProduct = _mapper.Map<Product>(Product);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }

        }


    }
}
