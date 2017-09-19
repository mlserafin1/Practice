using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    public class DapperContactsRepository : IContactsRepository
    {
        private string _connectString = ConfigurationManager.ConnectionStrings["myContacts"].ConnectionString;

        public void CreateContact(Contact contact)
        {

            using (SqlConnection conn = new SqlConnection(_connectString))
            {

                string insertContact = "CreateContact";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", contact.FirstName);
                parameters.Add("@LastName", contact.LastName);
                parameters.Add("@PhoneNumber", contact.PhoneNumber);
                parameters.Add("@Email", contact.Email);
                try
                {
                    conn.Execute(insertContact, parameters, commandType: CommandType.StoredProcedure);
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
                try
                {
                    results = conn.Query<Contact>("GetAllContacts", CommandType.StoredProcedure).ToList();
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

                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ID", id);
                    contact = conn.QueryFirst<Contact>("GetContactById", parameters, commandType: CommandType.StoredProcedure);
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

                string updateContact = "UpdateContact";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", contact.FirstName);
                parameters.Add("@LastName", contact.LastName);
                parameters.Add("@PhoneNumber", contact.PhoneNumber);
                parameters.Add("@Email", contact.Email);
                parameters.Add("@ID", contact.Id);
                try
                {
                    conn.Execute(updateContact, parameters, commandType: CommandType.StoredProcedure);
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

                string deleteContact = "DeleteContact";

                DynamicParameters parameters = new DynamicParameters();
                
                parameters.Add("@ID", id);
                try
                {
                    conn.Execute(deleteContact, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }
    }
}
