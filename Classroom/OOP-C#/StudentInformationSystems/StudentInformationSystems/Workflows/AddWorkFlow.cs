using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystems.BLL;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Workflows
{
    public class AddWorkFlow : IWorkFlow
    {
        public void Execute()
        {
            StudentManager manager = StudentManagerFactory.Create();
            Response<IEnumerable<Student>> response = manager.GetStudents(); 
            IEnumerable<Student> newList = response.Data;   //creates a list from the file so we can add to it
            Student student = new Student();

            student.Name = ConsoleIO.Prompt("Enter the student's name: ");
            student.GPA = decimal.Parse(ConsoleIO.Prompt("Enter the student's GPA: "));
            student.Id = newList.Count() + 1;

            Response<Student> response1 = manager.AddStudent(student);
            if (response1.Success)
            {
                ConsoleIO.Display("Student added!");
            }
            else
            {
                ConsoleIO.Display($"An error has occured \n{response1.Message}");
            }

        }
    }
}
