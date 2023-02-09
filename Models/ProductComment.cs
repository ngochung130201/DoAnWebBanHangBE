using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class ProductComment
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
        public Product Product { get; set; }
        public Guid ProductID { get; set; }

    }
}
