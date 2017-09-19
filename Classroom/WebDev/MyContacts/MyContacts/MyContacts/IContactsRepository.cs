using System.Collections.Generic;

namespace MyContacts
{
    public interface IContactsRepository
    {
        void CreateContact(Contact contact);
        void Delete(int id);
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void Update(Contact contact);
    }
}