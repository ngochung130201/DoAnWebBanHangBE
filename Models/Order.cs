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
        public Customer Customer { get; set; }
        public Guid CustomerID { get; set; }
        public int Discount { get; set; }
    }
}
