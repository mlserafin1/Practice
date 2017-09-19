using System.Data.Entity;

namespace Contacts
{
    public class ContactEntities : DbContext
    {
        public ContactEntities():base("myContacts")
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}