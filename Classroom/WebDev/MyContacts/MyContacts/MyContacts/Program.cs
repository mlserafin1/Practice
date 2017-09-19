using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    public class Program
    {
        static void Main(string[] args)
        {
            IContactsRepository repository = new ContactsRepository();

            Contact myContact = new Contact();
            Console.WriteLine("Enter your first name: ");
            myContact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            myContact.LastName = Console.ReadLine();
            Console.WriteLine("Enter your phone number: ");
            myContact.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your email address: ");
            myContact.Email = Console.ReadLine();

            repository.CreateContact(myContact);

            var myListContacts = repository.GetAll();


            foreach (var contact in myListContacts)
            {
                Console.WriteLine($"{contact.Id}\n\tName: {contact.FirstName} {contact.LastName}\n\tPhone: {contact.PhoneNumber}\n\tEmail: {contact.Email}");
                Console.WriteLine("-----------------------------------------------");
                Console.ReadLine();
            }
        }
    }
}
