using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Customer
    {
        [Key]
        public Guid ID { set; get; }
        public string FullName { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
    }
}
