using System;
using System.Collections.Generic;
using StudentInformationSystems.BLL;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Workflows
{
    public class DisplayWorkFlow : IWorkFlow
    {
        public void Execute()
        {
            StudentManager manager = StudentManagerFactory.Create();
            Response<IEnumerable<Student>> response = manager.GetStudents();
            if (response.Success)
            {
                foreach (var student in response.Data)
                {
                    ConsoleIO.Display($"Name: {student.Name}\nGPA:{student.GPA}");
                }
            }
            else
            {
                ConsoleIO.Display($"An error has occured \n{response.Message}");
            }
        }
    }
}