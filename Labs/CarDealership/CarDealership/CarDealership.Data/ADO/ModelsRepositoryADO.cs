using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Queries;

namespace CarDealership.Data.ADO
{
    public class ModelsRepositoryADO : IModelsRepository
    {
        public void CreateModel(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                if (model.UserId == null)
                {
                    cmd.Parameters.AddWithValue("@UserId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                }

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Model> GetAll()
        {
            List<Model> models = new List<Model>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = int.Parse(dr["ModelId"].ToString());
                        currentRow.MakeId = int.Parse(dr["MakeId"].ToString());
                        currentRow.ModelName = dr["ModelName"].ToString();
                        if (dr["DateAdded"] != DBNull.Value)
                        {
                            currentRow.DateAdded = dr["DateAdded"].ToString();
                        }
                        if (dr["UserId"] != DBNull.Value)
                        {
                            currentRow.UserId = dr["UserId"].ToString();
                        }

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public Make GetMakeIdByModelId(int id)
        {
            Make make = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetMakeIdByModelId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelId", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make = new Make();
                        Make currentRow = new Make();

                        currentRow.MakeId = int.Parse(dr["MakeId"].ToString());

                        make = currentRow;
                    }
                }
            }
            return make;
        }

        public IEnumerable<Model> GetModelByMakeId(int id)
        {
            List<Model> models = new List<Model>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetModelByMakeId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeId", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = int.Parse(dr["ModelId"].ToString());
                        currentRow.MakeId = int.Parse(dr["MakeId"].ToString());
                        currentRow.ModelName = dr["ModelName"].ToString();

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public IEnumerable<ModelViewModel> GetModelsAndMakes()
        {
            List<ModelViewModel> models = new List<ModelViewModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetModelsAndMakes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelViewModel currentRow = new ModelViewModel();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        if (dr["DateAdded"] != DBNull.Value)
                        {
                            currentRow.DateAdded = dr["DateAdded"].ToString();
                        }
                        if (dr["UserId"] != DBNull.Value)
                        {
                            currentRow.UserId = dr["UserId"].ToString();
                        }

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }
    }
}
