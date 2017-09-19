using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Static_Repos
{
    public class TestVehiclesRepository : IVehiclesRepository
    {
        public void CreateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleViewModel> GetAllAvailable()
        {
            throw new NotImplementedException();
        }

        public VehicleViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleViewModel> GetFeatured()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewVehicleInventoryReport> GetNewVehicleInventoryReport()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetRawVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesReport> GetSalesReports(SalesReportSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetSalesUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsedVehicleInventoryReport> GetUsedVehicleInventoryReport()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleViewModel> SearchAllAvailableVehicles(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleViewModel> SearchNewAvailableVehicles(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleViewModel> SearchUsedAvailableVehicles(VehicleSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
