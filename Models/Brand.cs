using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string ?Name { get; set; }
       
    }
}
