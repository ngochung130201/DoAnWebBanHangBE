using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class OrderModel
    {
        [Key]
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsStatus { get; set; }
        public bool Delivered { get; set; }
        public DateTime DeliveryDate { get; set; }
        public CustomerModel Customer { get; set; }
        public Guid CustomerID { get; set; }
        public int Discount { get; set; }
    }
}
