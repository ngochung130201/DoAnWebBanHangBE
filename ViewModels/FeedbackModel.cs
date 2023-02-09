using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class FeedbackModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Star { get; set; }
        public string Address { get; set; }

    }
}
