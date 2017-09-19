using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IVehiclesRepository
    {
        IEnumerable<VehicleViewModel> GetAll();
        IEnumerable<VehicleViewModel> GetAllAvailable();
        VehicleViewModel GetById(int id);
        void CreateVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int id);
        IEnumerable<VehicleViewModel> GetFeatured();
        IEnumerable<VehicleViewModel> SearchNewAvailableVehicles(VehicleSearchParameters parameters);
        IEnumerable<VehicleViewModel> SearchUsedAvailableVehicles(VehicleSearchParameters parameters);
        IEnumerable<VehicleViewModel> SearchAllAvailableVehicles(VehicleSearchParameters parameters);
        Vehicle GetRawVehicleById(int id);
        IEnumerable<NewVehicleInventoryReport> GetNewVehicleInventoryReport();
        IEnumerable<UsedVehicleInventoryReport> GetUsedVehicleInventoryReport();
        IEnumerable<SalesReport> GetSalesReports(SalesReportSearchParameters parameters);
        IEnumerable<User> GetSalesUsers();
    }
}
