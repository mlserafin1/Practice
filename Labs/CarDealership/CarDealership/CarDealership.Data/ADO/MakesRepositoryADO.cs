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
    public class MakesRepositoryADO : IMakesRepository
    {
        public void CreateMake(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                if (make.UserId == null)
                {
                    cmd.Parameters.AddWithValue("@UserId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UserId", make.UserId);
                }

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Make> GetAll()
        {
            List<Make> makes = new List<Make>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeId = int.Parse(dr["MakeId"].ToString());
                        currentRow.MakeName = dr["MakeName"].ToString();
                        if (dr["DateAdded"] != DBNull.Value)
                        {
                            currentRow.DateAdded = dr["DateAdded"].ToString();
                        }
                        if (dr["UserId"] != DBNull.Value)
                        {
                            currentRow.UserId = dr["UserId"].ToString();
                        }

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }
    }
}
