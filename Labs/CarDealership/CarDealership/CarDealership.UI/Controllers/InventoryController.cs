using CarDealership.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var repo = VehiclesRepositoryFactory.GetVehiclesRepository();

            var model = repo.GetById(id);
            return View(model);
        }
    }
}