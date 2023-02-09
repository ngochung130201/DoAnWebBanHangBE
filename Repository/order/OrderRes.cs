using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.order
{
    public class OrderRes : IOrder

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public OrderRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddOrderAsync(OrderModel Order)
        {
            var newOrder = _mapper.Map<Order>(Order);
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder.OrderID;
        }

        public async Task<List<OrderModel>> GetAllOrderAsync()
        {
            var OrderList = await _context.Orders.ToListAsync();
            return _mapper.Map<List<OrderModel>>(OrderList);
        }

        public async Task<OrderModel> GetOrderAsync(Guid id)
        {
            var resultDetailOrder = await _context.Orders.FindAsync(id);
            return _mapper.Map<OrderModel>(resultDetailOrder);
        }


        public async Task RemoveOrderAllAsync(List<OrderModel> Order)
        {
            foreach (var item in Order)
            {
                RemoveOrderAsync(item.OrderID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveOrderAsync(Guid id)
        {
            if (id != null)
            {
                var getOrder = await _context.Orders.FindAsync(id);
                if (getOrder != null)
                {
                    _context.Orders.Remove(getOrder);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateOrderAsync(Guid id, OrderModel Order)
        {

            if (id == Order.OrderID)
            {
                var updateOrder = _mapper.Map<Order>(Order);
                _context.Orders!.Update(updateOrder);
                await _context.SaveChangesAsync();
            }

        }


    }
}
