using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.invoice
{
    public class InvoiceRes : IInvoice

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public InvoiceRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddInvoiceAsync(InvoiceModel Invoice)
        {
            var newInvoice = _mapper.Map<Invoice>(Invoice);
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();
            return newInvoice.InvoiceID;
        }

        public async Task<List<InvoiceModel>> GetAllInvoiceAsync()
        {
            var InvoiceList = await _context.Invoices.ToListAsync();
            return _mapper.Map<List<InvoiceModel>>(InvoiceList);
        }

        public async Task<InvoiceModel> GetInvoiceAsync(Guid id)
        {
            var resultDetailInvoice = await _context.Invoices.FindAsync(id);
            return _mapper.Map<InvoiceModel>(resultDetailInvoice);
        }


        public async Task RemoveInvoiceAllAsync(List<InvoiceModel> Invoice)
        {
            foreach (var item in Invoice)
            {
                RemoveInvoiceAsync(item.InvoiceID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveInvoiceAsync(Guid id)
        {
            if (id != null)
            {
                var getInvoice = await _context.Invoices.FindAsync(id);
                if (getInvoice != null)
                {
                    _context.Invoices.Remove(getInvoice);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateInvoiceAsync(Guid id, InvoiceModel Invoice)
        {

            if (id == Invoice.InvoiceID)
            {
                var updateInvoice = _mapper.Map<Invoice>(Invoice);
                _context.Invoices!.Update(updateInvoice);
                await _context.SaveChangesAsync();
            }

        }


    }
}
