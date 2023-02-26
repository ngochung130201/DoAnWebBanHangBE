using DoAnBE.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class BrandModel
    {
        [Key]
        public int BrandID { get; set; }
        public string ?Name { get; set; }
      

    }
}
