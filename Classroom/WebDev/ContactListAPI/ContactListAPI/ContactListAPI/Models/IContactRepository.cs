using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListAPI.Models
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        void Create(Contact person);
        void Update(Contact person);
        void Delete(int id);
    }
}