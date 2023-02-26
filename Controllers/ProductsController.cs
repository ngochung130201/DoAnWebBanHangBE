using DoAnBE.Helper;
using DoAnBE.Models;
using DoAnBE.Repository.product;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IProduct _ProductRepo;
        public static int PAGE_SIZE { get; set; } = 38;
        public static int TotalPage { get; set; } = 1;
        public ProductsController(IProduct repo, ComputerdbContext context)

        {
            _context = context;
            _ProductRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct(string? sort, string? search,int page )
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
                  BrandName = b.Name,
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
                  MetaKeyword =  pro.MetaKeyword,
                  CateID = cate.CateID,
                  PercentPrice = pro.PercentPrice,
                  IsFreeship = pro.IsFreeship,
              }
              ).ToListAsync();
            if(search != null)
            {
                ProductList = ProductList.Where(x => x.Name.ToLower().Contains(search)).ToList();
            }
            if (!String.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "price_desc":
                        ProductList = ProductList.OrderByDescending(x => x.Price).ToList();
                        break;
                    case "price_asc":
                        ProductList = ProductList.OrderBy(x => x.Price).ToList();
                        break;
                    case "quantity10":
                        ProductList = ProductList.Where(x => x.Quantity < 10).ToList();
                      
                        break;
                    default:
                        ProductList = ProductList.OrderBy(x => x.CreateDate).ToList();
                        break;
                }
            }
            if (page <= 0)
            {
                var totalProducts = ProductList.Count();
                page = 1;

                var totalPages = (int)Math.Ceiling((double)totalProducts / PAGE_SIZE);

                var products = ProductList
                    
                    .Take(PAGE_SIZE)
                    .ToList();

                return Ok(new
                {
                    TotalPages = totalPages,
                    Products = products,
                    countProduct = totalProducts
                });
            }

            else
            {
                var totalProducts = ProductList.Count();
                var totalPages = (int)Math.Ceiling((double)totalProducts / PAGE_SIZE);

                var products = ProductList
                    .Skip((page - 1) * PAGE_SIZE)
                    .Take(PAGE_SIZE)
                    .ToList();

                return Ok(new
                {
                    TotalPages = totalPages,
                    Products = products,
                    countProduct = totalProducts
                });
            }
         

        }
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetIdProduct(string slug)
        {
           if(slug == null)
            {
                return BadRequest();
            }
           //var getidProduct = await _context.Products.FindAsync(id);

            var getidProduct = await (
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
                  BrandName = b.Name,
                  BrandID = pro.BrandID,
                  CateID = cate.CateID,
                  CreateBy = pro.CreateBy,
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
                  Supplierid = pro.Supplierid,
                  SupplierName = s.Name,
                  SupplierAdress = s.Address,
                  SupplierEmail = s.Email,
                  SupplierPhone = s.Phone,
                  CategoryName = cate.Name,
                  MetaKeyword = pro.MetaKeyword,
                  PercentPrice = pro.PercentPrice,
                  IsFreeship = pro.IsFreeship,
              }
              ).SingleOrDefaultAsync(x=>x.Slug == slug);
            
            return Ok(getidProduct);


        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel Product)
        {
            try
            {
                var newProduct = await _ProductRepo.AddProductAsync(Product);
                return Ok(newProduct);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            try
            {
                await _ProductRepo.RemoveProductAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductModel Product)
        {
            if (id != Product.ProductID)
            {
                return NotFound();
            }
            await _ProductRepo.UpdateProductAsync(id, Product);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(List<ProductModel> Products)
        {
            var listProduct = await _context.Products.ToListAsync();
            await _ProductRepo.RemoveProductAllAsync(Products);
            return Ok(Products);
        }

    }
}
