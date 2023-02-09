using DoAnBE.ViewModels;

namespace DoAnBE.Repository.orderDetail
{
    public interface IOrderDetail
    {
        public Task<List<OrderDetailModel>> GetAllOrderDetailAsync();
        public Task<Guid> AddOrderDetailAsync(OrderDetailModel OrderDetail);
        public Task<OrderDetailModel> GetOrderDetailAsync(Guid id);
        public Task UpdateOrderDetailAsync(Guid id, OrderDetailModel OrderDetail);
        public Task RemoveOrderDetailAsync(Guid id);
        public Task RemoveOrderDetailAllAsync(List<OrderDetailModel> OrderDetail);
    }
}
