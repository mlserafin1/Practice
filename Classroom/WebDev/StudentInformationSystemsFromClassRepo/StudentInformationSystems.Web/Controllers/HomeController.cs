using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentInformationSystems.BLL;
using StudentInformationSystems.Models;
using StudentInformationSystems.Web.Models;

namespace StudentInformationSystems.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StudentManager manager = StudentManagerFactory.SetupManager();
            List<Student> students = manager.GetStudents().Data.ToList();
            return View(students);
        }

        public ActionResult Delete(int id)
        {
            StudentManager manager = StudentManagerFactory.SetupManager();
            Student student = manager.GetStudentById(id).Data;
            return View(student);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            StudentManager manager = StudentManagerFactory.SetupManager();
            manager.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Major> majors = new List<Major>
            {
                new Major() {Id = 1, Name = "Computer Science"},
                new Major() {Id = 2, Name = "Memes Science"},
                new Major() {Id = 3, Name = "Advance Trolling Phil"},
            };
            List<SelectListItem> favThings = new List<SelectListItem>
            {
                new SelectListItem(){Text = "None", Value = "",Selected = false},
                new SelectListItem(){Text = "Books", Value = "1",Selected = true},
                new SelectListItem(){Text = "Games", Value = "2",Selected = false},
            };
            //ViewBag.AvailableMajors = majors;
            CreateStudentVM vm = new CreateStudentVM();
            vm.SetAvailableMajors(majors);
            return View(vm);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentManager manager = StudentManagerFactory.SetupManager();
            Student student = manager.GetStudentById(id).Data;

            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(int id, string name, decimal gpa)
        {
            StudentManager manager = StudentManagerFactory.SetupManager();
            Response<Student> response = manager.GetStudentById(id);
            if (!response.Success) return RedirectToAction("Index");

            Student student = response.Data;
            student.Name = name;
            student.GPA = gpa;
            Response<Student> editResponse = manager.UpdateStudent(student);
            if (editResponse.Success)
            {
                return RedirectToAction("Index");
            }
            {
                ModelState.AddModelError("", editResponse.Message);
                return View(student);
            }
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            StudentManager manager = StudentManagerFactory.SetupManager();

            var response = manager.AddStudent(student);
            if (response.Success)
            {
                ModelState.Clear();
                var vm = new CreateStudentVM();
                List<Major> majors = new List<Major>
            {
                new Major() {Id = 1, Name = "Computer Science"},
                new Major() {Id = 2, Name = "Memes Science"},
                new Major() {Id = 3, Name = "Advance Trolling Phil"},
            };
                vm.SetAvailableMajors(majors);
                vm.Message = "Your Student Id is: " + student.Id;
                return View(vm);
            }
            ModelState.AddModelError("", response.Message);
            return View();
        }
    }
}