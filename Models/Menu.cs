using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public bool IsStatus { get; set; }
    }
}
