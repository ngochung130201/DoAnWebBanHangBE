using DoAnBE.Models;
using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class SupplierModel
    {
        [Key]
        public Guid SupplierID { get; set; }
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không hợp lệ !.")]
        public string? Phone { get; set; }
  

    }
}
