using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    public class ContactsRepository : IContactsRepository
    {
        private string _connectString = ConfigurationManager.ConnectionStrings["myContacts"].ConnectionString;

        public void CreateContact(Contact contact)
        {
            
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                string insertContact = "INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Email) Values(@FirstName,@LastName,@PhoneNumber,@Email)";

                SqlCommand cmd = new SqlCommand(insertContact, conn);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery(); //use this method when you do an insert or an update
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public IEnumerable<Contact> GetAll()
        {
            List<Contact> results = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand("Select Id,FirstName,LastName,PhoneNumber,Email From Contacts", conn);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); //use this for executing queries
                    while (dr.Read())
                    {
                        Contact c = new Contact();

                        c.Id = int.Parse(dr["Id"].ToString());
                        c.FirstName = dr["FirstName"].ToString();
                        c.LastName = dr["LastName"].ToString();
                        c.PhoneNumber = dr["PhoneNumber"].ToString();
                        c.Email = dr["Email"].ToString();
                        results.Add(c);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return results;
        }
        
        public Contact GetById(int id)
        {
            Contact contact = null;

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand("Select Id,FirstName,LastName,PhoneNumber,Email From Contacts WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); //use this for executing queries
                    while (dr.Read())
                    {
                        Contact c = new Contact();

                        c.Id = int.Parse(dr["Id"].ToString());
                        c.FirstName = dr["FirstName"].ToString();
                        c.LastName = dr["LastName"].ToString();
                        c.PhoneNumber = dr["PhoneNumber"].ToString();
                        c.Email = dr["Email"].ToString();
                        contact = c;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return contact;
        }

        public void Update(Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                string updateContact = "UPDATE Contacts set FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(updateContact, conn);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@ID", contact.Id); //forces parameters
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery(); //use this method when you do an insert or an update
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                string deleteContact = "DELETE FROM Contacts WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(deleteContact, conn);

                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery(); //use this method when you do an insert or an update or delete
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
