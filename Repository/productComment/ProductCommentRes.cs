using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.productComment
{
    public class ProductCommentRes : IProductComment

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public ProductCommentRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddProductCommentAsync(ProductCommentModel ProductComment)
        {
            var newProductComment = _mapper.Map<ProductComment>(ProductComment);
            _context.ProductComments.Add(newProductComment);
            await _context.SaveChangesAsync();
            return newProductComment.ProductID;
        }

        public async Task<List<ProductCommentModel>> GetAllProductCommentAsync()
        {
            var ProductCommentList = await _context.ProductComments.ToListAsync();
            return _mapper.Map<List<ProductCommentModel>>(ProductCommentList);
        }

        public async Task<ProductCommentModel> GetProductCommentAsync(Guid id)
        {
            var resultDetailProductComment = await _context.ProductComments.FindAsync(id);
            return _mapper.Map<ProductCommentModel>(resultDetailProductComment);
        }


        public async Task RemoveProductCommentAllAsync(List<ProductCommentModel> ProductComment)
        {
            foreach (var item in ProductComment)
            {
                RemoveProductCommentAsync(item.ProductID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProductCommentAsync(Guid id)
        {
            if (id != null)
            {
                var getProductComment = await _context.ProductComments.FindAsync(id);
                if (getProductComment != null)
                {
                    _context.ProductComments.Remove(getProductComment);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateProductCommentAsync(Guid id, ProductCommentModel ProductComment)
        {

            if (id == ProductComment.ProductID)
            {
                var updateProductComment = _mapper.Map<ProductComment>(ProductComment);
                _context.ProductComments!.Update(updateProductComment);
                await _context.SaveChangesAsync();
            }

        }


    }
}
