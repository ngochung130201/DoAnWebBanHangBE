using DoAnBE.Models;
using DoAnBE.Repository.invoice;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IInvoice _InvoiceRepo;

        public InvoicesController(IInvoice repo, ComputerdbContext context)

        {
            _context = context;
            _InvoiceRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoice()
        {
            var result = await _InvoiceRepo.GetAllInvoiceAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdInvoice(Guid id)
        {
            var Invoice = await _InvoiceRepo.GetInvoiceAsync(id);
            return Invoice == null ? NotFound() : Ok(Invoice);


        }
        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceModel Invoice)
        {
            try
            {
                var result = await _InvoiceRepo.AddInvoiceAsync(Invoice);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveInvoice(Guid id)
        {
            try
            {
                await _InvoiceRepo.RemoveInvoiceAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(Guid id, InvoiceModel Invoice)
        {
            if (id != Invoice.InvoiceID)
            {
                return NotFound();
            }
            await _InvoiceRepo.UpdateInvoiceAsync(id, Invoice);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveInvoice(List<InvoiceModel> Invoices)
        {
            var listInvoice = await _context.Invoices.ToListAsync();
            await _InvoiceRepo.RemoveInvoiceAllAsync(Invoices);
            return Ok(Invoices);
        }

    }
}
