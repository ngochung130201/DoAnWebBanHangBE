using AutoMapper;
using DoAnBE.Helper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task<Guid> AddProductAsync(ProductModel Products)
        {
            var newProduct = new Product
            {
                ProductID = Guid.NewGuid(),
                Supplierid = Products.Supplierid,
                CateID = Products.CateID,
                BrandID = Products.BrandID,
                CreateBy = Products.CreateBy,
                CreateDate = DateTime.Now,
                Description = Products.Description,
                Detail = Products.Detail,
                Image = Products.Image,
                Hot = Products.Hot,
                IsVat = Products.IsVat,
                ListImage = Products.ListImage,
                MetaDescription = Products.MetaDescription,
                MetaKeyword = Products.MetaKeyword,
                Name = Products.Name,
                Price = Products.Price,
                PromotionPrice= Products.PromotionPrice,
                Quantity = Products.Quantity,
                Slug = Common.Slugify(Products.Name),
                UpdateBy = Products.UpdateBy,
                UpdateDate = DateTime.Now,
                ViewCount = Products.ViewCount,
                PercentPrice =Products.PercentPrice,
                IsFreeship= Products.IsFreeship,

            };
            //if(Products.Images.Length > 0)
            //{
            //    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",Products.Images.FileName);
            //    using (var stream = System.IO.File.Create(path))
            //    {
            //        await Products.Images.CopyToAsync(stream);
            //    };
            //    newProduct.Image = "/images/"+ Products.Images.FileName;

            //}
            //else
            //{
            //    newProduct.Image = "";
            //}
          

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.ProductID;
        }

            public async Task<List<ProductModel>> GetAllProductAsync()
        {
           var ProductList = await (
              from pro in _context.Products
              join b in _context.Brands 
              on pro.BrandID equals b.BrandID
              join s in _context.Suppliers on pro.Supplierid equals s.SupplierID
              join cate in _context.ProductCategories on pro.CateID equals cate.CateID
              select new
              {
                  
                  ProductID = pro.ProductID,
                  Name = pro.Name,
                  Price = pro.Price,
                  Brand = pro.Brand,
                  BrandID = pro.BrandID,
                  CreateBy=pro.CreateBy,
                  PromotionPrice = pro.PromotionPrice,
                  CreateDate = pro.CreateDate,
                  UpdateDate = pro.UpdateDate,
                  IsVat = pro.IsVat,
                  UpdateBy = pro.UpdateBy,
                  Quantity = pro.Quantity,
                  Hot = pro.Hot,
                  Description = pro.Description,
                  MetaDescription = pro.MetaDescription,
                  Detail = pro.Detail,
                  Image = pro.Image,
                  ListImage = pro.ListImage,
                  Slug = pro.Slug,
                  ViewCount = pro.ViewCount,
                  Supplierid= pro.Supplierid,
                  SupplierName = s.Name,
                  SupplierAdress = s.Address,
                  SupplierEmail = s.Email,
                  SupplierPhone = s.Phone,
                   CategoryName = cate.Name,

              }
              ).ToListAsync();
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
                var updateProduct = await _context.Products.FindAsync(id);
                updateProduct.Price = Product.Price;
                updateProduct.Supplierid = Product.Supplierid;
                updateProduct.CateID = Product.CateID;
                updateProduct.BrandID = Product.BrandID;
                updateProduct.CreateBy = Product.CreateBy;
                updateProduct.CreateDate = DateTime.Now;
                updateProduct.Description = Product.Description;
                updateProduct.Detail = Product.Detail;
                updateProduct.Hot = Product.Hot;
                updateProduct.Image = Product.Image;
                updateProduct.IsVat = Product.IsVat;
                updateProduct.ListImage = Product.ListImage;
                updateProduct.MetaDescription = Product.MetaDescription;
                updateProduct.MetaKeyword = Product.MetaKeyword;
                updateProduct.Name = Product.Name;
                updateProduct.PromotionPrice = Product.PromotionPrice;
                updateProduct.Quantity = Product.Quantity;
                 updateProduct.Slug = Common.Slugify(Product.Name);
                updateProduct.UpdateBy = Product.UpdateBy;
                updateProduct.UpdateDate = DateTime.Now;
                updateProduct.IsFreeship= Product.IsFreeship;
                updateProduct.PercentPrice= Product.PercentPrice;
                updateProduct.ViewCount = Product.ViewCount;
                _context.Products.Update(updateProduct);
                await _context.SaveChangesAsync();
            }

        }


    }
}
