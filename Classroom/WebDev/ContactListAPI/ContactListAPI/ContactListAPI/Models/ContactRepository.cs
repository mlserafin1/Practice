using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListAPI.Models
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> _contacts;
        public ContactRepository()
        {
            if (_contacts != null)
            {
                return;
            }

            _contacts = new List<Contact>();
            _contacts.Add(new Contact()
            {
                Id = 1,
                FirstName = "Jimmy",
                LastName = "Phillips",
                PhoneNumber = "312-167-2986",
                Email = "jp@aol.com"
            });
            _contacts.Add(new Contact()
            {
                Id = 2,
                FirstName = "Wilma",
                LastName = "Sotts",
                PhoneNumber = "465-283-4973",
                Email = "ws@yahoo.com"
            });
        }
        public void Create(Contact person)
        {
            var nextId = 1;
            if (_contacts.Any())
            {
                nextId = nextId + _contacts.Max(s => s.Id);
            }
            person.Id = nextId;
            _contacts.Add(person);
        }

        public void Delete(int id)
        {
            _contacts.RemoveAll(s => s.Id == id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Contact person)
        {
            Delete(person.Id);
            _contacts.Add(person);
        }
    }
}