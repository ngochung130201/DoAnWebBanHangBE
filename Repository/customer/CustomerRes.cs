using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.customer
{
    public class CustomerRes : ICustomer

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public CustomerRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddCustomerAsync(CustomerModel Customer)
        {
            var newCustomer = _mapper.Map<Customer>(Customer);
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.ID;
        }

        public async Task<List<CustomerModel>> GetAllCustomerAsync()
        {
            var CustomerList = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerModel>>(CustomerList);
        }

        public async Task<CustomerModel> GetCustomerAsync(Guid id)
        {
            var resultDetailCustomer = await _context.Customers.FindAsync(id);
            return _mapper.Map<CustomerModel>(resultDetailCustomer);
        }


        public async Task RemoveCustomerAllAsync(List<CustomerModel> Customer)
        {
            foreach (var item in Customer)
            {
                RemoveCustomerAsync(item.ID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCustomerAsync(Guid id)
        {
            if (id != null)
            {
                var getCustomer = await _context.Customers.FindAsync(id);
                if (getCustomer != null)
                {
                    _context.Customers.Remove(getCustomer);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateCustomerAsync(Guid id, CustomerModel Customer)
        {

            if (id == Customer.ID)
            {
                var updateCustomer = _mapper.Map<Customer>(Customer);
                _context.Customers!.Update(updateCustomer);
                await _context.SaveChangesAsync();
            }

        }


    }
}
