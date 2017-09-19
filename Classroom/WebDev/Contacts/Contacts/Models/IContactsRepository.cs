using System.Collections.Generic;

namespace Contacts
{
    public interface IContactsRepository
    {
        void CreateContact(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void Update(Contact contact);
        void Delete(int id);
    }
}