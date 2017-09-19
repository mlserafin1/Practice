using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactsRepository repository = new EfContactsRepository();

            Contact myContact = new Contact();
            Console.WriteLine("Enter Your First Name:");
            myContact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name:");
            myContact.LastName = Console.ReadLine();
            Console.WriteLine("Enter Your Phone number:");
            myContact.Phone = Console.ReadLine();
            Console.WriteLine("Enter Your Email:");
            myContact.Email = Console.ReadLine();

            repository.CreateContact(myContact);

            var myListContacts = repository.GetAll();

            myListContacts.ToList().ForEach(r => DisplayContact(r));
            

            foreach (var contact in myListContacts)
            {
                DisplayContact(contact);
            }
            Console.ReadLine();
        }

        private static void DisplayContact(Contact contact)
        {
            Console.WriteLine($"{contact.Id} \n\t Name: {contact.FirstName} {contact.LastName} \n\t Email: {contact.Email} \n\t Phone: {contact.Phone}");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
