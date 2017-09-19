using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Contacts
{
 
    public class DapperContactsRepository : IContactsRepository
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", contact.FirstName);
                parameters.Add("@LastName", contact.LastName);
                parameters.Add("@Phone", contact.Phone);
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
        //ReadAll
        public IEnumerable<Contact> GetAll()
        {
            List<Contact> results = new List<Contact>();
            //Selecting Contacts 
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                try
                {
                  results =  conn.Query<Contact>(selectContact, CommandType.StoredProcedure).ToList();
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
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ID", id);
                    contact = conn.QueryFirst<Contact>("GetContactByID", parameters, commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", contact.FirstName);
                parameters.Add("@LastName", contact.LastName);
                parameters.Add("@Phone", contact.Phone);
                parameters.Add("@Email", contact.Email);
                parameters.Add("@ID",contact.Id);
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
        //Delete
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
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