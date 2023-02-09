using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.orderDetail
{
    public class OrderDetailRes : IOrderDetail

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public OrderDetailRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddOrderDetailAsync(OrderDetailModel OrderDetail)
        {
            var newOrderDetail = _mapper.Map<OrderDetail>(OrderDetail);
            _context.OrderDetails.Add(newOrderDetail);
            await _context.SaveChangesAsync();
            return newOrderDetail.Id;
        }

        public async Task<List<OrderDetailModel>> GetAllOrderDetailAsync()
        {
            var OrderDetailList = await _context.OrderDetails.ToListAsync();
            return _mapper.Map<List<OrderDetailModel>>(OrderDetailList);
        }

        public async Task<OrderDetailModel> GetOrderDetailAsync(Guid id)
        {
            var resultDetailOrderDetail = await _context.OrderDetails.FindAsync(id);
            return _mapper.Map<OrderDetailModel>(resultDetailOrderDetail);
        }


        public async Task RemoveOrderDetailAllAsync(List<OrderDetailModel> OrderDetail)
        {
            foreach (var item in OrderDetail)
            {
                RemoveOrderDetailAsync(item.OrderDetailId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveOrderDetailAsync(Guid id)
        {
            if (id != null)
            {
                var getOrderDetail = await _context.OrderDetails.FindAsync(id);
                if (getOrderDetail != null)
                {
                    _context.OrderDetails.Remove(getOrderDetail);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateOrderDetailAsync(Guid id, OrderDetailModel OrderDetail)
        {

            if (id == OrderDetail.OrderDetailId)
            {
                var updateOrderDetail = _mapper.Map<OrderDetail>(OrderDetail);
                _context.OrderDetails!.Update(updateOrderDetail);
                await _context.SaveChangesAsync();
            }

        }


    }
}
