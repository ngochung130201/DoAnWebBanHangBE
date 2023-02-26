using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class OrderDetailModel
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
