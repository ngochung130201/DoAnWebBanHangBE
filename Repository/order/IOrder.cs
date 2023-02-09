using DoAnBE.ViewModels;

namespace DoAnBE.Repository.order
{
    public interface IOrder
    {
        public Task<List<OrderModel>> GetAllOrderAsync();
        public Task<Guid> AddOrderAsync(OrderModel Order);
        public Task<OrderModel> GetOrderAsync(Guid id);
        public Task UpdateOrderAsync(Guid id, OrderModel Order);
        public Task RemoveOrderAsync(Guid id);
        public Task RemoveOrderAllAsync(List<OrderModel> Order);
    }
}
