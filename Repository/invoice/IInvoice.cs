using DoAnBE.ViewModels;

namespace DoAnBE.Repository.invoice
{
    public interface IInvoice
    {
        public Task<List<InvoiceModel>> GetAllInvoiceAsync();
        public Task<Guid> AddInvoiceAsync(InvoiceModel Invoice);
        public Task<InvoiceModel> GetInvoiceAsync(Guid id);
        public Task UpdateInvoiceAsync(Guid id, InvoiceModel Invoice);
        public Task RemoveInvoiceAsync(Guid id);
        public Task RemoveInvoiceAllAsync(List<InvoiceModel> Invoice);
    }
}
