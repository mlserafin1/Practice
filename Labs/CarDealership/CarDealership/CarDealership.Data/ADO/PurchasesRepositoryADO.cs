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
    public class PurchasesRepositoryADO : IPurchasesRepository
    {
        public void AddPurchase(Purchase purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddPurchase", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@PurchaseId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@PurchaseTypeId", purchase.PurchaseTypeId);
                //cmd.Parameters.AddWithValue("@PurchaseDate", (DateTime.Now).ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@UserId", purchase.UserId);
                if (string.IsNullOrEmpty(purchase.Message))
                {
                    cmd.Parameters.AddWithValue("@Message", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Message", purchase.Message);
                };
                cmd.Parameters.AddWithValue("@CustomerInfoId", purchase.CustomerInfoId);
                cmd.Parameters.AddWithValue("@Price", purchase.Price);


                cn.Open();

                cmd.ExecuteNonQuery();

                purchase.PurchaseId = (int)param.Value;
            }
        }

        public IEnumerable<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchasesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase();
                        currentRow.PurchaseId = int.Parse(dr["PurchaseId"].ToString());
                        currentRow.PurchaseTypeId = int.Parse(dr["PurchaseTypeId"].ToString());
                        currentRow.PurchaseDate = dr["PurchaseDate"].ToString();
                        currentRow.UserId = dr["UserId"].ToString();
                        if (dr["Message"] != DBNull.Value)
                        {
                            currentRow.Message = dr["Message"].ToString();
                        }
                        currentRow.CustomerInfoId = int.Parse(dr["CustomerInfoId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());

                        purchases.Add(currentRow);
                    }
                }
            }
            return purchases;
        }
    }
}
