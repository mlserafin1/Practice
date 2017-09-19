using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class CustomerInfoRepositoryADO : ICustomerInfoRepository
    {
        public void AddCustomer(CustomerInfo customer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddCustomerInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CustomerInfoId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Address1", customer.Address1);
                if (string.IsNullOrEmpty(customer.Address2))
                {
                    cmd.Parameters.AddWithValue("@Address2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Address2", customer.Address2);
                }
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@State", customer.State);
                cmd.Parameters.AddWithValue("@Zip", customer.Zip);
                if (string.IsNullOrEmpty(customer.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                }
                if (string.IsNullOrEmpty(customer.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                }


                cn.Open();

                cmd.ExecuteNonQuery();

                customer.CustomerInfoId = (int)param.Value;
            }
        }

        public IEnumerable<CustomerInfo> GetAll()
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomersSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CustomerInfo currentRow = new CustomerInfo();
                        currentRow.CustomerInfoId = int.Parse(dr["CustomerInfoId"].ToString());
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Address1 = dr["Address1"].ToString();
                        if(dr["Address2"] != DBNull.Value)
                        {
                            currentRow.Address2 = dr["Address2"].ToString();
                        }
                        currentRow.City = dr["City"].ToString();
                        currentRow.State = dr["State"].ToString();
                        currentRow.Zip = dr["Zip"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Email = dr["Email"].ToString();

                        customers.Add(currentRow);
                    }
                }
            }
            return customers;
        }
    }
}
