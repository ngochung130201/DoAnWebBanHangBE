namespace DoAnBE.ViewModels
{
    public class ProductLinq
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int BrandID { get; set; }
        public string CreateBy { get; set; }
        public decimal PromotionPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsVat { get; set; }
        public string UpdateBy { get; set; }
        public int Quantity { get; set; }
        public bool Hot { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public string ListImage { get; set; }
        public string Slug { get; set; }
        public int ViewCount { get; set; }
        public int Supplierid { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAdress { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhone { get; set; }
        public string CategoryName { get; set; }
    }
}
