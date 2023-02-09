using DoAnBE.ViewModels;

namespace DoAnBE.Repository.supplier
{
    public interface ISupplier
    {
        public Task<List<SupplierModel>> GetAllSupplierAsync();
        public Task<Guid> AddSupplierAsync(SupplierModel Supplier);
        public Task<SupplierModel> GetSupplierAsync(Guid id);
        public Task UpdateSupplierAsync(Guid id, SupplierModel Supplier);
        public Task RemoveSupplierAsync(Guid id);
        public Task RemoveSupplierAllAsync(List<SupplierModel> Supplier);
    }
}
