using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Supplier
    {
        [Key]
        public Guid SupplierID { get; set; }
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ !")]
        public string Email { get; set; }
        public string Address { get; set; }
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Số điện thoại không hợp lệ !.")]
        public string Phone { get; set; }

    }
}
