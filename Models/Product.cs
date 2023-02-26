using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Product
    {
        [Key]
        public Guid ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        public string ?Slug { get; set; }
        public string ?Image { get; set; }
        public float? PercentPrice { get; set; }
        public bool? IsFreeship { get; set; }
        public string ?ListImage { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set;}
        public bool? IsVat { get; set; }
        public int? Quantity { get; set; }
        public DateTime ?Hot { get; set; }
        public string? Detail { get; set; }
        public string? Description { get; set; }
        public int? ViewCount { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ProductCategory ?ProductCategory { get; set; }
        public Guid? CateID { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid? Supplierid { get; set;}
        public Brand? Brand { get; set; }
        public int? BrandID { get; set; }


    }
}
