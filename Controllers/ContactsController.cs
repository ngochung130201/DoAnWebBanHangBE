using DoAnBE.Models;
using DoAnBE.Repository.contact;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IContact _ContactRepo;

        public ContactsController(IContact repo, ComputerdbContext context)

        {
            _context = context;
            _ContactRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var result = await _ContactRepo.GetAllContactAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdContact(int id)
        {
            var Contact = await _ContactRepo.GetContactAsync(id);
            return Contact == null ? NotFound() : Ok(Contact);


        }
        [HttpPost]
        public async Task<IActionResult> AddContact(ContactModel Contact)
        {
            try
            {
                var result = await _ContactRepo.AddContactAsync(Contact);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            try
            {
                await _ContactRepo.RemoveContactAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactModel Contact)
        {
            if (id != Contact.ContactId)
            {
                return NotFound();
            }
            await _ContactRepo.UpdateContactAsync(id, Contact);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(List<ContactModel> Contacts)
        {
            var listContact = await _context.Contacts.ToListAsync();
            
            return Ok(listContact);
        }

    }
}
