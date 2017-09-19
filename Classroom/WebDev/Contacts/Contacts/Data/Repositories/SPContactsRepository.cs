using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Contacts
{

    public class SPContactsRepository : IContactsRepository
    {
        private const string deleteContact = "DeleteContact";
        private const string updateContact = "UpdateContact";
        private const string selectContact = "GetAllContacts";
        private const string insertContact = "CreateContact";

        private string _connectString = ConfigurationManager.ConnectionStrings["myContacts"].ConnectionString;
        //Create
        public void CreateContact(Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {

                SqlCommand cmd = new SqlCommand(insertContact, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        //ReadAll
        public IEnumerable<Contact> GetAll()
        {
            List<Contact> results = new List<Contact>();
            //Selecting Contacts 
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand(selectContact, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Contact c = new Contact();

                        c.Id = int.Parse(dr["Id"].ToString());
                        c.FirstName = dr["FirstName"].ToString();
                        c.LastName = dr["LastName"].ToString();
                        c.Phone = dr["Phone"].ToString();
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
        //ReadByID
        public Contact GetById(int id)
        {
            Contact contact = null;
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand("GetContactById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Contact c = new Contact();

                        c.Id = int.Parse(dr["Id"].ToString());
                        c.FirstName = dr["FirstName"].ToString();
                        c.LastName = dr["LastName"].ToString();
                        c.Phone = dr["Phone"].ToString();
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
        //Update
        public void Update(Contact contact)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
               

                SqlCommand cmd = new SqlCommand(updateContact, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@ID", contact.Id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        //Delete
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                

                SqlCommand cmd = new SqlCommand(deleteContact, conn);
               
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
