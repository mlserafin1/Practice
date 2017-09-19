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
        public ActionResult Index(Tip tip) //or(decimal BillTotal, decimal TipPercent)
        {
            //tip.BillTotal = BillTotal;
            //tip.TipPercent = TipPercent;
            tip.TotalWithCalculatedTip = tip.BillTotal +(tip.BillTotal * (tip.TipPercent / 100));
            return View(tip);
        }
    }
}