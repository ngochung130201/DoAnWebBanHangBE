using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Post
    {
        [Key]
        public Guid PostID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
