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
    public class PurchaseTypesRepositoryADO : IPurchaseTypesRepository
    {
        public IEnumerable<PurchaseType> GetAll()
        {
            List<PurchaseType> purchaseTypes = new List<PurchaseType>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseType currentRow = new PurchaseType();
                        currentRow.PurchaseTypeId = int.Parse(dr["PurchaseTypeId"].ToString());
                        currentRow.PurchaseTypeName = dr["PurchaseType"].ToString();

                        purchaseTypes.Add(currentRow);
                    }
                }
            }
            return purchaseTypes;
        }
    }
}
