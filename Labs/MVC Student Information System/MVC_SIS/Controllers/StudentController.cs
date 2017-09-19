using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            
            


            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();
                var temp = StudentRepository.GetAll();
                studentVM.Student.StudentId = temp.Max(m => m.StudentId) + 1;

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List");
            }

            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            return View("Add", studentVM);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = StudentRepository.Get(id);

            var vm = new StudentVM();
            vm.Student = student;

            //need to add courses that the student is enrolled in
            //vm.SetCourseItems(student.Courses);
            vm.SetCourseItems(CourseRepository.GetAll());
            vm.SetMajorItems(MajorRepository.GetAll());
            vm.SetStateItems(StateRepository.GetAll());

            return View(vm);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
           
            if (ModelState.IsValid)//model state comes in false when it shouldnt
            {
                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                studentVM.Student.Courses = new List<Course>();
                foreach (var id in studentVM.CourseItems.Where(m => m.Selected))
                    studentVM.Student.Courses.Add(CourseRepository.Get(int.Parse(id.Value)));
                //foreach (var id in studentVM.SelectedCourseIds)
                //studentVM.Student.Courses.Add(CourseRepository.Get(id));
                StudentRepository.Edit(studentVM.Student);

                return RedirectToAction("List");
            }

            
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            return View("EditStudent", studentVM);

        }

        [HttpPost]
        public ActionResult EditAddress(StudentVM studentVM)
        {

            StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}