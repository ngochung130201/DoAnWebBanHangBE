using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.supplier
{
    public class SupplierRes : ISupplier

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public SupplierRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddSupplierAsync(SupplierModel Supplier)
        {
            var newSupplier = new Supplier
            {
                SupplierID = Guid.NewGuid(),
                Address= Supplier.Address,
                Email= Supplier.Email,
                Name= Supplier.Name,
                Phone= Supplier.Phone
            };
            _context.Suppliers.Add(newSupplier);
            await _context.SaveChangesAsync();
            return newSupplier.SupplierID;
        }

        public async Task<List<SupplierModel>> GetAllSupplierAsync()
        {
            var SupplierList = await _context.Suppliers.ToListAsync();
            return _mapper.Map<List<SupplierModel>>(SupplierList);
        }

        public async Task<SupplierModel> GetSupplierAsync(Guid id)
        {
            var resultDetailSupplier = await _context.Suppliers.FindAsync(id);
            return _mapper.Map<SupplierModel>(resultDetailSupplier);
        }


        public async Task RemoveSupplierAllAsync(List<SupplierModel> Supplier)
        {
            foreach (var item in Supplier)
            {
                RemoveSupplierAsync(item.SupplierID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveSupplierAsync(Guid id)
        {
            if (id != null)
            {
                var getSupplier = await _context.Suppliers.FindAsync(id);
                if (getSupplier != null)
                {
                    _context.Suppliers.Remove(getSupplier);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateSupplierAsync(Guid id, SupplierModel Supplier)
        {

            if (id == Supplier.SupplierID)
            {
                var updateSupplier = _mapper.Map<Supplier>(Supplier);
                _context.Suppliers!.Update(updateSupplier);
                await _context.SaveChangesAsync();
            }

        }


    }
}
