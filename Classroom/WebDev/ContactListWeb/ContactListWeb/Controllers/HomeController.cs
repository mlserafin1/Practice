using ContactListWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ContactListWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FileUploadViewModel model)
        {
            if(model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"),
                    Path.GetFileName(model.UploadedFile.FileName));

                model.UploadedFile.SaveAs(path);
            }
            return View();
        }
    }
}