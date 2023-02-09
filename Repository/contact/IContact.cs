using DoAnBE.ViewModels;

namespace DoAnBE.Repository.contact
{
    public interface IContact
    {
        public Task<List<ContactModel>> GetAllContactAsync();
        public Task<int> AddContactAsync(ContactModel Contact);
        public Task<ContactModel> GetContactAsync(int id);
        public Task UpdateContactAsync(int id, ContactModel Contact);
        public Task RemoveContactAsync(int id);
        public Task RemoveContactAllAsync(List<ContactModel> Contact);
    }
}
