using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;
using System.Data.SqlClient;
using System.Data;
using CarDealership.Models.Queries;

namespace CarDealership.Data.ADO
{
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public void CreateVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                if(vehicle.PurchaseId == 0)
                {
                    cmd.Parameters.AddWithValue("@PurchaseId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PurchaseId", vehicle.PurchaseId);
                } 
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@Interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                if (string.IsNullOrEmpty(vehicle.PictureFileName))
                {
                    cmd.Parameters.AddWithValue("@PictureFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PictureFileName", vehicle.PictureFileName);
                }
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleId = (int)param.Value;
            }
        }

        public void DeleteVehicle(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", id);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<VehicleViewModel> GetAll()
        {
            List<VehicleViewModel> vehicles = new List<VehicleViewModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) //if returning more than one object, write while
                    {
                        VehicleViewModel currentRow = new VehicleViewModel();
                        currentRow.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            currentRow.PurchaseId = int.Parse(dr["VehicleId"].ToString());
                        }
                        currentRow.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        }
                        currentRow.IsFeatured = bool.Parse(dr["IsFeatured"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleViewModel> GetAllAvailable()
        {
            List<VehicleViewModel> vehicles = new List<VehicleViewModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAllAvailable", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) //if returning more than one object, write while
                    {
                        VehicleViewModel currentRow = new VehicleViewModel();
                        currentRow.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            currentRow.PurchaseId = int.Parse(dr["VehicleId"].ToString());
                        }
                        currentRow.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        }
                        currentRow.IsFeatured = bool.Parse(dr["IsFeatured"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public VehicleViewModel GetById(int id)
        {
            VehicleViewModel vehicle = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicleById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) //if returning one object, write if
                    {
                        vehicle = new VehicleViewModel();
                        vehicle.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        vehicle.Price = decimal.Parse(dr["Price"].ToString());
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.Model = dr["ModelName"].ToString();
                        vehicle.Make = dr["MakeName"].ToString();
                        vehicle.Year = dr["Year"].ToString();
                        vehicle.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            vehicle.PurchaseId = int.Parse(dr["VehicleId"].ToString());
                        }
                        vehicle.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        vehicle.Color = dr["Color"].ToString();
                        vehicle.Interior = dr["Interior"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            vehicle.PictureFileName = dr["PictureFileName"].ToString();
                        }
                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<VehicleViewModel> GetFeatured()
        {
            List<VehicleViewModel> vehicles = new List<VehicleViewModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturedVehiclesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) //if returning more than one object, write while
                    {
                        VehicleViewModel currentRow = new VehicleViewModel();
                        currentRow.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            currentRow.PurchaseId = int.Parse(dr["VehicleId"].ToString());
                        }
                        currentRow.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        }
                        currentRow.IsFeatured = bool.Parse(dr["IsFeatured"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<NewVehicleInventoryReport> GetNewVehicleInventoryReport()
        {
            List<NewVehicleInventoryReport> vehicles = new List<NewVehicleInventoryReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT v.[Year],ma.MakeName, mo.ModelName,Count(v.VehicleId) AS [Count], SUM(v.Price) AS StockValue FROM Vehicles v INNER JOIN Models mo on v.ModelId = mo.ModelId INNER JOIN Makes ma on mo.MakeId = ma.MakeId WHERE v.IsNew = 1 AND v.PurchaseId IS NULL GROUP BY v.[Year], ma.MakeName, mo.ModelName ORDER BY ma.MakeName";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        NewVehicleInventoryReport currentRow = new NewVehicleInventoryReport();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Count = int.Parse(dr["Count"].ToString());
                        currentRow.StockValue = decimal.Parse(dr["StockValue"].ToString());
                        
                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public Vehicle GetRawVehicleById(int id)
        {
            Vehicle vehicle = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetRawVehicleById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleId", id);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) //if returning one object, write if
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        vehicle.Price = decimal.Parse(dr["Price"].ToString());
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.ModelId = int.Parse(dr["ModelId"].ToString());
                        vehicle.Year = dr["Year"].ToString();
                        vehicle.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            vehicle.PurchaseId = int.Parse(dr["VehicleId"].ToString());
                        }
                        vehicle.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        vehicle.Color = dr["Color"].ToString();
                        vehicle.Interior = dr["Interior"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            vehicle.PictureFileName = dr["PictureFileName"].ToString();
                        }
                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<SalesReport> GetSalesReports(SalesReportSearchParameters parameters)
        {
            List<SalesReport> reports = new List<SalesReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT  a.FirstName, a.LastName, SUM(p.Price) AS TotalSales, COUNT(p.PurchaseId) AS TotalVehicles FROM Purchases p INNER JOIN AspNetUsers a ON p.UserId = a.Id WHERE 1 = 1 ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.UserId))
                {
                    query += "AND p.UserId = @UserId ";
                    cmd.Parameters.AddWithValue("@UserId", parameters.UserId);
                }

                if (!string.IsNullOrEmpty(parameters.MinDate))
                {
                    query += "AND p.PurchaseDate >= @MinDate ";
                    cmd.Parameters.AddWithValue("@MinDate", parameters.MinDate);
                }

                if (!string.IsNullOrEmpty(parameters.MaxDate))
                {
                    query += "AND p.PurchaseDate <= @MaxDate ";
                    cmd.Parameters.AddWithValue("@MaxDate", parameters.MaxDate);
                }

                query += "GROUP BY a.FirstName, a.LastName";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReport currentRow = new SalesReport();
                        currentRow.User = dr["FirstName"].ToString();
                        currentRow.User += " ";
                        currentRow.User += dr["LastName"].ToString();
                        currentRow.TotalSales = decimal.Parse(dr["TotalSales"].ToString());
                        currentRow.TotalVehicles = int.Parse(dr["TotalVehicles"].ToString());
                        reports.Add(currentRow);
                    }
                }
            }
            return reports;
        }

        public IEnumerable<User> GetSalesUsers()
        {
            List<User> users = new List<User>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "Select u.FirstName, u.LastName, u.Id from AspNetUsers u inner join AspNetUserRoles r on u.Id = r.UserId where r.RoleId = '2'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User currentRow = new User();
                        currentRow.Name = dr["FirstName"].ToString();
                        currentRow.Name += " ";
                        currentRow.Name += dr["LastName"].ToString();
                        currentRow.UserId = dr["Id"].ToString();

                        users.Add(currentRow);
                    }
                }
            }
            return users;
        }

        public IEnumerable<UsedVehicleInventoryReport> GetUsedVehicleInventoryReport()
        {
            List<UsedVehicleInventoryReport> vehicles = new List<UsedVehicleInventoryReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT v.[Year],ma.MakeName, mo.ModelName,Count(v.VehicleId) AS [Count], SUM(v.Price) AS StockValue FROM Vehicles v INNER JOIN Models mo on v.ModelId = mo.ModelId INNER JOIN Makes ma on mo.MakeId = ma.MakeId WHERE v.IsNew = 0 AND v.PurchaseId IS NULL GROUP BY v.[Year], ma.MakeName, mo.ModelName ORDER BY ma.MakeName";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UsedVehicleInventoryReport currentRow = new UsedVehicleInventoryReport();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Count = int.Parse(dr["Count"].ToString());
                        currentRow.StockValue = decimal.Parse(dr["StockValue"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleViewModel> SearchAllAvailableVehicles(VehicleSearchParameters parameters)
        {
            List<VehicleViewModel> vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured FROM Vehicles v INNER JOIN Models m ON v.ModelId = m.ModelId INNER JOIN Makes a on m.MakeId = a.MakeId WHERE v.PurchaseId IS NULL ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.TextBoxTerm))
                {
                    query += "AND (m.Modelname LIKE @TextBoxTerm OR a.MakeName LIKE @TextBoxTerm OR v.[Year] LIKE @TextBoxTerm) ";
                    cmd.Parameters.AddWithValue("@TextBoxTerm", parameters.TextBoxTerm + '%');
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND v.Price >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND v.Price <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinYear))
                {
                    query += "AND v.[Year] >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (!string.IsNullOrEmpty(parameters.MaxYear))
                {
                    query += "AND v.[Year] <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                query += "ORDER BY v.Msrp DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel currentRow = new VehicleViewModel();
                        currentRow.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            currentRow.PurchaseId = int.Parse(dr["PurchaseId"].ToString());
                        }
                        currentRow.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        }
                        currentRow.IsFeatured = bool.Parse(dr["IsFeatured"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleViewModel> SearchNewAvailableVehicles(VehicleSearchParameters parameters)
        {
            List<VehicleViewModel> vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured FROM Vehicles v INNER JOIN Models m ON v.ModelId = m.ModelId INNER JOIN Makes a on m.MakeId = a.MakeId WHERE v.IsNew = 1 AND v.PurchaseId IS NULL ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.TextBoxTerm))
                {
                    query += "AND (m.Modelname LIKE @TextBoxTerm OR a.MakeName LIKE @TextBoxTerm OR v.[Year] LIKE @TextBoxTerm) ";
                    cmd.Parameters.AddWithValue("@TextBoxTerm", parameters.TextBoxTerm + '%');
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND v.Price >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND v.Price <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinYear))
                {
                    query += "AND v.[Year] >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (!string.IsNullOrEmpty(parameters.MaxYear))
                {
                    query += "AND v.[Year] <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                query += "ORDER BY v.Msrp DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel currentRow = new VehicleViewModel();
                        currentRow.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            currentRow.PurchaseId = int.Parse(dr["PurchaseId"].ToString());
                        }
                        currentRow.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        }
                        currentRow.IsFeatured = bool.Parse(dr["IsFeatured"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleViewModel> SearchUsedAvailableVehicles(VehicleSearchParameters parameters)
        {
            List<VehicleViewModel> vehicles = new List<VehicleViewModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 v.VehicleId, v.Price, v.Vin, a.MakeName, m.ModelName, v.[Year], v.IsNew, v.PurchaseId, v.Msrp, v.Color, v.Interior, v.Transmission, v.Mileage, v.[Description], v.BodyStyle, v.PictureFileName, v.IsFeatured FROM Vehicles v INNER JOIN Models m ON v.ModelId = m.ModelId INNER JOIN Makes a on m.MakeId = a.MakeId WHERE v.IsNew = 0 AND v.PurchaseId IS NULL ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.TextBoxTerm))
                {
                    query += "AND (m.Modelname LIKE @TextBoxTerm OR a.MakeName LIKE @TextBoxTerm OR v.[Year] LIKE @TextBoxTerm) ";
                    cmd.Parameters.AddWithValue("@TextBoxTerm", parameters.TextBoxTerm + '%');
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND v.Price >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND v.Price <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinYear))
                {
                    query += "AND v.[Year] >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear);
                }

                if (!string.IsNullOrEmpty(parameters.MaxYear))
                {
                    query += "AND v.[Year] <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear);
                }

                query += "ORDER BY v.Msrp DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleViewModel currentRow = new VehicleViewModel();
                        currentRow.VehicleId = int.Parse(dr["VehicleId"].ToString());
                        currentRow.Price = decimal.Parse(dr["Price"].ToString());
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Make = dr["MakeName"].ToString();
                        currentRow.Model = dr["ModelName"].ToString();
                        currentRow.Year = dr["Year"].ToString();
                        currentRow.IsNew = bool.Parse(dr["IsNew"].ToString());
                        if (dr["PurchaseId"] != DBNull.Value)
                        {
                            currentRow.PurchaseId = int.Parse(dr["PurchaseId"].ToString());
                        }
                        currentRow.Msrp = decimal.Parse(dr["Msrp"].ToString());
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        if (dr["PictureFileName"] != DBNull.Value)
                        {
                            currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        }
                        currentRow.IsFeatured = bool.Parse(dr["IsFeatured"].ToString());

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                if (vehicle.PurchaseId == 0)
                {
                    cmd.Parameters.AddWithValue("@PurchaseId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PurchaseId", vehicle.PurchaseId);
                }
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@Interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                if (string.IsNullOrEmpty(vehicle.PictureFileName))
                {
                    cmd.Parameters.AddWithValue("@PictureFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PictureFileName", vehicle.PictureFileName);
                }
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
