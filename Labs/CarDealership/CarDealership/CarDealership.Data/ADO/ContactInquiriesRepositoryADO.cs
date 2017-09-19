using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace CarDealership.Data.ADO
{
    public class ContactInquiriesRepositoryADO : IContactInquiriesRepository
    {
        public void AddInquiry(ContactInquiry contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddContactInquiry", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", contact.Name);
                if (string.IsNullOrEmpty(contact.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                }
                if (string.IsNullOrEmpty(contact.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                }
                if (string.IsNullOrEmpty(contact.Message))
                {
                    cmd.Parameters.AddWithValue("@Message", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Message", contact.Message);
                }
                
                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<ContactInquiry> GetAll()
        {
            List<ContactInquiry> contactInquiries = new List<ContactInquiry>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInquiriesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ContactInquiry currentRow = new ContactInquiry();
                        currentRow.ContactInfoId = int.Parse(dr["ContactInfoId"].ToString());
                        currentRow.Name = dr["Name"].ToString();
                        if (dr["Phone"] != DBNull.Value)
                        {
                            currentRow.Phone = dr["Phone"].ToString();
                        }
                        if (dr["Email"] != DBNull.Value)
                        {
                            currentRow.Email = dr["Email"].ToString();
                        }
                        if (dr["Message"] != DBNull.Value)
                        {
                            currentRow.Message = dr["Message"].ToString();
                        }

                        contactInquiries.Add(currentRow);
                    }
                }
            }
            return contactInquiries;
        }
    }
}
