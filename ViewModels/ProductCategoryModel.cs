using DoAnBE.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    // Bang danh muc san pham
    public class ProductCategoryModel
    {
        [Key]
        public Guid CateID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsStatus { get; set; }
        public int Sort { get; set; }
        public int ParentID { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
