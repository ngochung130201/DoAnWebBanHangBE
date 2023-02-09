using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class InvoiceModel
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
        public SupplierModel Supplier { get; set; }
        public Guid SupplierID { get; set; }

    }
}
