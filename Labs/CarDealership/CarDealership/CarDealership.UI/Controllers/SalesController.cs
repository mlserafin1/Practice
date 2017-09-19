using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            var model = new PurchaseViewModel();
            var vehicleRepo = VehiclesRepositoryFactory.GetVehiclesRepository();
            var purchaseTypeRepo = PurchaseTypesRepositoryFactory.GetPurchaseTypesRepository();
           
            model.Vehicle = vehicleRepo.GetById(id);
            model.PurchasesTypes = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeId", "PurchaseTypeName");
            model.Customer = new CustomerInfo();
            //model.Purchase = new Purchase();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                var model1 = new PurchaseViewModel();
                var vehicleRepo1 = VehiclesRepositoryFactory.GetVehiclesRepository();
                var purchaseTypeRepo = PurchaseTypesRepositoryFactory.GetPurchaseTypesRepository();

                model1.Vehicle = vehicleRepo1.GetById(id);
                model1.PurchasesTypes = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeId", "PurchaseTypeName");
                model1.Customer = new CustomerInfo();
                return View(model1);
            }

                var vehicleRepo = VehiclesRepositoryFactory.GetVehiclesRepository();
            var purchaseRepo = PurchasesRepositoryFactory.GetPurchasesRepository();
            var customerInfoRepo = CustomerInfoFactory.GetCustomerInfoRepository();

            var testCar = vehicleRepo.GetRawVehicleById(id);

            customerInfoRepo.AddCustomer(model.Customer);
            model.Purchase.CustomerInfoId = model.Customer.CustomerInfoId;
            //add model.Purchase.UserId
            if (Request.IsAuthenticated)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = manager.FindByName(User.Identity.Name);
                model.Purchase.UserId = user.Id;
            }
            else
            {
                model.Purchase.UserId = "00000000-0000-0000-0000-000000000000";
            }

            model.Purchase.Message = testCar.Vin;


            purchaseRepo.AddPurchase(model.Purchase);
            testCar.PurchaseId = model.Purchase.PurchaseId;
            vehicleRepo.UpdateVehicle(testCar);

            return RedirectToAction("SaleConfirmation");
        }

        [HttpGet]
        public ActionResult SaleConfirmation()
        {
            return View();
        }
    }
}