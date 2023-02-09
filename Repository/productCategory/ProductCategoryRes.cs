using AutoMapper;
using DoAnBE.Helper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.productCategory
{
    public class ProductCategoryRes : IProductCategory

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public ProductCategoryRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddProductCategoryAsync(ProductCategoryModel ProductCategory)
        {
         
            var newProductCategory = new ProductCategory
            {
                CateID = Guid.NewGuid(),
                Name= ProductCategory.Name,
                CreateBy= ProductCategory.CreateBy,
                CreateDate = DateTime.Now,
                IsStatus= ProductCategory.IsStatus,
                MetaDescription= ProductCategory.MetaDescription,
                MetaKeyword= ProductCategory.MetaKeyword,
                ParentID= ProductCategory.ParentID,
                Slug= Common.Slugify(ProductCategory.Name),
                Sort= ProductCategory.Sort,
                UpdateBy= ProductCategory.UpdateBy,
                UpdateDate = DateTime.Now
            };
            _context.ProductCategories.Add(newProductCategory);
            await _context.SaveChangesAsync();
            return newProductCategory.CateID;
        }

        public async Task<List<ProductCategoryModel>> GetAllProductCategoryAsync()
        {
            var ProductCategoryList = await _context.ProductCategories.ToListAsync();
            return _mapper.Map<List<ProductCategoryModel>>(ProductCategoryList);
        }

        public async Task<ProductCategoryModel> GetProductCategoryAsync(string slug)
        {
            var resultDetailProductCategory = await _context.ProductCategories.SingleOrDefaultAsync(x=>x.Slug == slug);
            return _mapper.Map<ProductCategoryModel>(resultDetailProductCategory);
        }


        public async Task RemoveProductCategoryAllAsync(List<ProductCategoryModel> ProductCategory)
        {
            foreach (var item in ProductCategory)
            {
                RemoveProductCategoryAsync(item.CateID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProductCategoryAsync(Guid id)
        {
            if (id != null)
            {
                var getProductCategory = await _context.ProductCategories.FindAsync(id);
                if (getProductCategory != null)
                {
                    _context.ProductCategories.Remove(getProductCategory);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateProductCategoryAsync(string slug, ProductCategoryModel ProductCategory)
        {

            if (slug == ProductCategory.Slug)
            {
                var productCategoryEdit =  _context.ProductCategories.FirstOrDefault(x => x.Slug == slug);
                if(productCategoryEdit!= null)
                {
                    productCategoryEdit.Name = ProductCategory.Name;
                    productCategoryEdit.Slug = Common.Slugify(ProductCategory.Name);
                    productCategoryEdit.UpdateDate = DateTime.Now;
                    productCategoryEdit.CreateDate = DateTime.Now;
                    productCategoryEdit.CreateBy= ProductCategory.CreateBy;
                    productCategoryEdit.UpdateBy= ProductCategory.UpdateBy;
                    productCategoryEdit.Sort = ProductCategory.Sort;
                    productCategoryEdit.IsStatus = ProductCategory.IsStatus;
                    productCategoryEdit.MetaDescription = ProductCategory.MetaDescription;
                    productCategoryEdit.MetaKeyword = ProductCategory.MetaKeyword;
                    productCategoryEdit.ParentID = ProductCategory.ParentID;

                }
                _context.ProductCategories!.Update(productCategoryEdit);
                await _context.SaveChangesAsync();
            }

        }


    }
}
