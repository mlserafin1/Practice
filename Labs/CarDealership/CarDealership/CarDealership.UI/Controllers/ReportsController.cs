using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            var vehiclesRepo = VehiclesRepositoryFactory.GetVehiclesRepository();
            var reports = new VehicleInventoryReportViewModel();
            reports.New = vehiclesRepo.GetNewVehicleInventoryReport();
            reports.Used = vehiclesRepo.GetUsedVehicleInventoryReport();

            return View(reports);
        }

        public ActionResult Sales()
        {
            var model = new SalesReportViewModel();
            var vehicle = VehiclesRepositoryFactory.GetVehiclesRepository();
            model.Users = new SelectList(vehicle.GetSalesUsers(), "UserId", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Sales(SalesReportSearchParameters parameters)
        {
            var model = new SalesReportViewModel();
            var vehicle = VehiclesRepositoryFactory.GetVehiclesRepository();
            model.Users = new SelectList(vehicle.GetSalesUsers(), "UserId", "Name");
            var vehiclesRepo = VehiclesRepositoryFactory.GetVehiclesRepository();
            model.Sales = vehiclesRepo.GetSalesReports(parameters);
            return View(model);
        }
    }
}