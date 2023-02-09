using DoAnBE.ViewModels;

namespace DoAnBE.Repository.customer
{
    public interface ICustomer
    {
        public Task<List<CustomerModel>> GetAllCustomerAsync();
        public Task<Guid> AddCustomerAsync(CustomerModel Customer);
        public Task<CustomerModel> GetCustomerAsync(Guid id);
        public Task UpdateCustomerAsync(Guid id, CustomerModel Customer);
        public Task RemoveCustomerAsync(Guid id);
        public Task RemoveCustomerAllAsync(List<CustomerModel> Customer);
    }
}
