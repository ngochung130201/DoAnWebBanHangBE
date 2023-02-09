using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class PostComment
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
        public Post Post { get; set; }
        public Guid PostID { get; set; }
    }
}
