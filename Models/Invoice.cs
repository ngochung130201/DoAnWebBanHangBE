using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceID { get; set; }
        public bool IsStatus { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public int DeleteBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Supplier Supplier { get; set; }
        public Guid SupplierID { get; set; }

    }
}
