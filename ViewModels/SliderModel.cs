using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class SliderModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public bool IsStatus { get; set; }
    }
}
