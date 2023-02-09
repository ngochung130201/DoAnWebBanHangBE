using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class AboutModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool  IsStatus { get; set; }
    }
}
