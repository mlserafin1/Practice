using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Web.Models
{
    public class CreateStudentVM
    {
        public CreateStudentVM()
        {
            Student = new Student();
        }
        public Student Student { get; set; }

        public List<SelectListItem> AvailableMajors { get; set; }
        public string Message { get; set; }

        public void SetAvailableMajors(IEnumerable<Major> majors)
        {
            AvailableMajors = new List<SelectListItem>();
            foreach (var major in majors)
            {
                SelectListItem s = new SelectListItem();
                s.Text = major.Name;
                s.Value = major.Id.ToString();
                AvailableMajors.Add(s);
            }
        }
    }
}