using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = VehiclesRepositoryFactory.GetVehiclesRepository().GetFeatured();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string vin)
        {
            ViewBag.Vin = vin;
            return View();
        }

        public ActionResult ContactSuccess()
        {
            ViewBag.Confirmation = "Inquiry sent!";
            return View("Contact");
        }

        [HttpPost]
        public ActionResult AddInquiry(ContactInquiry contact)
        {
            var repo = ContactInquiriesFactory.GetContactInquiriesRepository();

            repo.AddInquiry(contact);
            return RedirectToAction("ContactSuccess");
        }
    }
}