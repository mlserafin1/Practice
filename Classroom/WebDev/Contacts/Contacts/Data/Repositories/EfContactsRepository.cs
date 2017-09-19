using System.Collections.Generic;
using System.Data.Entity;

namespace Contacts
{
    public class EfContactsRepository : IContactsRepository
    {
        private ContactEntities _ctx;

        public EfContactsRepository()
        {
            this._ctx = new ContactEntities();
        }

        public void CreateContact(Contact contact)
        {
            _ctx.Contacts.Add(contact);
            _ctx.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _ctx.Contacts;
        }

        public Contact GetById(int id)
        {
            return _ctx.Contacts.Find(id);
        }

        public void Update(Contact contact)
        {
            _ctx.Entry(contact).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Contacts.Remove(GetById(id));
        }
    }
}