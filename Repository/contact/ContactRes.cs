using AutoMapper;
using DoAnBE.Models;
using DoAnBE.Repository.contact;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.contact
{
    public class ContactRes : IContact

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public ContactRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> AddContactAsync(ContactModel Contact)
        {
            var newContact = _mapper.Map<Contact>(Contact);
            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();
            return newContact.ContactId ;
        }

        public async Task<List<ContactModel>> GetAllContactAsync()
        {
            var ContactList = await _context.Contacts.ToListAsync();
            return _mapper.Map<List<ContactModel>>(ContactList);
        }

        public async Task<ContactModel> GetContactAsync(int id)
        {
            var resultDetailContact = await _context.Contacts.FindAsync(id);
            return _mapper.Map<ContactModel>(resultDetailContact);
        }


     

        public async Task RemoveContactAsync(int id)
        {
            if (id != null)
            {
                var getContact = await _context.Contacts.FindAsync(id);
                if (getContact != null)
                {
                    _context.Contacts.Remove(getContact);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateContactAsync(int id, ContactModel Contact)
        {

            if (id == Contact.ContactId)
            {
                var updateContact = _mapper.Map<Contact>(Contact);
                _context.Contacts!.Update(updateContact);
                await _context.SaveChangesAsync();
            }

        }

      

        public async Task RemoveContactAllAsync(List<ContactModel> contact)
        {
            foreach (var item in contact)
            {
                RemoveContactAsync(item.ContactId);
                await _context.SaveChangesAsync();
            }
        }
    }
}
