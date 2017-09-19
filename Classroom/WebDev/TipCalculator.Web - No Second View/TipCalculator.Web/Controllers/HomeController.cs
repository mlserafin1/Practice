using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Web.Models;

namespace TipCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal BillTotal, decimal TipPercent)
        {
            Tip tip = new Tip();
            tip.BillTotal = BillTotal;
            tip.TipPercent = TipPercent;
            tip.CalculatedTip = BillTotal * (TipPercent / 100);
            return View(tip);
        }
    }
}