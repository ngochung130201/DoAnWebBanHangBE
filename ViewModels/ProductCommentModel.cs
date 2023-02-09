using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class ProductCommentModel
    {
        [Key]
        public Guid CommentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Detail { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ProductModel Product { get; set; }
        public Guid ProductID { get; set; }

    }
}
