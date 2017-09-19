using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVDLibrary.DATA
{
    public class DvdRepositoryADO : IDvdRepository
    {
        private string _connectString = ConfigurationManager.ConnectionStrings["dvdLibrary"].ConnectionString;

        public void Create(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "CreateDvd";
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@RatingID", dvd.RatingId);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
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

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "DeleteDvd";

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

        public IEnumerable<Dvd> GetAll()
        {
            List<Dvd> results = new List<Dvd>();
            //Selecting Dvds 
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SelectAllDvds";

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.Id = int.Parse(dr["ID"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        if(dr["DirectorName"] != DBNull.Value)
                        {
                            d.DirectorName = dr["DirectorName"].ToString();
                        }
                        d.RatingType = dr["RatingType"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return results;
        }

        public Dvd GetById(int id)
        {
            Dvd result = new Dvd();

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetDvdById";
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dvd d = new Dvd();

                        d.Id = int.Parse(dr["ID"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            d.DirectorName = dr["DirectorName"].ToString();
                        }
                        d.RatingType = dr["RatingType"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        result = d;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return result;
        }

        public void Update(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "UpdateDvd";

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@RatingID", dvd.RatingId);
                //cmd.Parameters.AddWithValue("@RatingType", dvd.RatingType);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                cmd.Parameters.AddWithValue("@ID", dvd.Id);
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

        public IEnumerable<DvdListView> SearchForTitle(string title)
        {
            List<DvdListView> results = new List<DvdListView>();

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SearchForTitle";
                cmd.Parameters.AddWithValue("@Title", title);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DvdListView d = new DvdListView();

                        d.Id = int.Parse(dr["ID"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            d.DirectorName = dr["DirectorName"].ToString();
                        }
                        d.RatingType = dr["RatingType"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return results;
        }

        public IEnumerable<DvdListView> SearchForYear(string releaseYear)
        {
            List<DvdListView> results = new List<DvdListView>();

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SearchForYear";
                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DvdListView d = new DvdListView();

                        d.Id = int.Parse(dr["ID"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            d.DirectorName = dr["DirectorName"].ToString();
                        }
                        d.RatingType = dr["RatingType"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return results;
        }

        public IEnumerable<DvdListView> SearchForDirector(string directorName)
        {
            List<DvdListView> results = new List<DvdListView>();

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SearchForDirector";
                cmd.Parameters.AddWithValue("@DirectorName", directorName);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DvdListView d = new DvdListView();

                        d.Id = int.Parse(dr["ID"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            d.DirectorName = dr["DirectorName"].ToString();
                        }
                        d.RatingType = dr["RatingType"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return results;
        }

        public IEnumerable<DvdListView> SearchForRating(string rating)
        {
            List<DvdListView> results = new List<DvdListView>();

            using (SqlConnection conn = new SqlConnection(_connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SearchForRating";
                cmd.Parameters.AddWithValue("@RatingType", rating);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DvdListView d = new DvdListView();

                        d.Id = int.Parse(dr["ID"].ToString());
                        d.Title = dr["Title"].ToString();
                        d.ReleaseYear = dr["ReleaseYear"].ToString();
                        if (dr["DirectorName"] != DBNull.Value)
                        {
                            d.DirectorName = dr["DirectorName"].ToString();
                        }
                        d.RatingType = dr["RatingType"].ToString();
                        d.Notes = dr["Notes"].ToString();
                        results.Add(d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return results;
        }
    }
}