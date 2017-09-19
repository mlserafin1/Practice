using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()//do a new view (create) here. This will get the info from the form, and send it to the Post method
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal BillTotal, decimal TipPercent)
        {

            Tip newTip = new Tip();
            newTip.BillTotal = BillTotal;
            newTip.TipPercent = TipPercent;
            newTip.CalculatedTip = BillTotal + (BillTotal * (TipPercent / 100));

            return View("CalculatedTip",newTip);//do a new empty view with model on calculatedtip, pass it a tip type, and display Model.CalculatedTip
        }
    }
}