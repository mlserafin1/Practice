using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vehicles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var model = new AddVehicleViewModel();
            var repo = MakesRepositoryFactory.GetMakesRepository();
            model.Makes = new SelectList(repo.GetAll(), "MakeId", "MakeName");
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel model) //took out int ModelId
        {
            if (!ModelState.IsValid)
            {
                var model1 = new AddVehicleViewModel();
                var repo1 = MakesRepositoryFactory.GetMakesRepository();
                model1.Makes = new SelectList(repo1.GetAll(), "MakeId", "MakeName", true);
                return View(model1);
            }
            //vehicle.ModelId = ModelId;
            
            var repo = VehiclesRepositoryFactory.GetVehiclesRepository();

            repo.CreateVehicle(model.Vehicle);
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Images");

                string fileName = "inventory-" + model.Vehicle.VehicleId;//Path.GetFileNameWithoutExtension(UploadedFile.FileName);
                string extension = Path.GetExtension(model.UploadedFile.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                    counter++;
                }

                model.UploadedFile.SaveAs(filePath);
                model.Vehicle.PictureFileName = Path.GetFileName(filePath);
            }
            repo.UpdateVehicle(model.Vehicle);
            return RedirectToAction("EditVehicle", new { id = model.Vehicle.VehicleId });
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var model = new EditVehicleViewModel();
            var makesRepo = MakesRepositoryFactory.GetMakesRepository();
            var modelsRepo = ModelsRepositoryFactory.GetModelsRepository();
            var vehicleRepo = VehiclesRepositoryFactory.GetVehiclesRepository();
           
            model.Vehicle = vehicleRepo.GetRawVehicleById(id);
            var test = modelsRepo.GetMakeIdByModelId(model.Vehicle.ModelId);
            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName", modelsRepo.GetMakeIdByModelId(model.Vehicle.ModelId));//get make id from repo
            return View(model);
        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehicleViewModel model)//took out  int ModelId
        {
            //vehicle.ModelId = ModelId;
            if (!ModelState.IsValid)
            {
                var model1 = new EditVehicleViewModel();
                var makesRepo1 = MakesRepositoryFactory.GetMakesRepository();
                var modelsRepo1 = ModelsRepositoryFactory.GetModelsRepository();
                var vehicleRepo1 = VehiclesRepositoryFactory.GetVehiclesRepository();

                model1.Vehicle = vehicleRepo1.GetRawVehicleById(model.Vehicle.VehicleId);
                var test1 = modelsRepo1.GetMakeIdByModelId(model.Vehicle.ModelId);
                model1.Makes = new SelectList(makesRepo1.GetAll(), "MakeId", "MakeName", modelsRepo1.GetMakeIdByModelId(model.Vehicle.ModelId));//get make id from repo
                return View(model1);
            }

            if(model.UploadedFile == null)
            {
                var vehicleRepo = VehiclesRepositoryFactory.GetVehiclesRepository();
                var tempVehicle = vehicleRepo.GetById(model.Vehicle.VehicleId);
                model.Vehicle.PictureFileName = tempVehicle.PictureFileName;
            }
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Images");

                string fileName = "inventory-" + model.Vehicle.VehicleId;//Path.GetFileNameWithoutExtension(UploadedFile.FileName);
                string extension = Path.GetExtension(model.UploadedFile.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension); //change file save path here
                    counter++;
                }

                model.UploadedFile.SaveAs(filePath);
                model.Vehicle.PictureFileName = Path.GetFileName(filePath);
            }
            var repo = VehiclesRepositoryFactory.GetVehiclesRepository();

            repo.UpdateVehicle(model.Vehicle);
            return RedirectToAction("Vehicles");
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var repo = VehiclesRepositoryFactory.GetVehiclesRepository();
            var vehicle = repo.GetById(id);
            return View(vehicle);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var repo = VehiclesRepositoryFactory.GetVehiclesRepository();
            var temp = repo.GetById(id);
            var savepath = Server.MapPath("~/Images");
            
            var filePath = Path.Combine(savepath, temp.PictureFileName);
            System.IO.File.Delete(filePath);
            repo.DeleteVehicle(id);
            return View();
        }

        [HttpGet]
        public ActionResult Makes()
        {
            var repo = MakesRepositoryFactory.GetMakesRepository();
            var makes = repo.GetAll();
            return View(makes);
        }

        [HttpPost]
        public ActionResult Makes(string make)
        {
            var repo = MakesRepositoryFactory.GetMakesRepository();
            var newMake = new Make();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindByName(User.Identity.Name);
            newMake.UserId = user.Email;
            newMake.MakeName = make;
            repo.CreateMake(newMake);
            var makes = repo.GetAll();
            return View(makes);
        }

        [HttpGet]
        public ActionResult Models()
        {
            var makesRepo = MakesRepositoryFactory.GetMakesRepository();
            var modelsRepo = ModelsRepositoryFactory.GetModelsRepository();
            var makes = new AddModelViewModel();
            makes.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            makes.MakesAndModels = modelsRepo.GetModelsAndMakes();
            return View(makes);
        }

        [HttpPost]
        public ActionResult Models(string name, Model model)
        {
            var makesRepo = MakesRepositoryFactory.GetMakesRepository();
            var modelsRepo = ModelsRepositoryFactory.GetModelsRepository();
            var newModel = new Model();
            var makes = new AddModelViewModel();

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindByName(User.Identity.Name);

            newModel.UserId = user.Email;
            newModel.MakeId = model.MakeId;
            newModel.ModelName = name;
            modelsRepo.CreateModel(newModel);

            makes.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            makes.MakesAndModels = modelsRepo.GetModelsAndMakes();
            return View(makes);
        }
    }
}