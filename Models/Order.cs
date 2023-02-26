using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsStatus { get; set; }
        public bool Delivered { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Customer? Customer { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public bool IsFreeShip { get; set; }
        public decimal? PriceSum { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}
