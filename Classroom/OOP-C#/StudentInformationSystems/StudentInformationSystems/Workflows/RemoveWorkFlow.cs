using System;
using System.Collections.Generic;
using StudentInformationSystems.BLL;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Workflows
{
    public class RemoveWorkFlow : IWorkFlow
    {
        public void Execute()
        {
            //Prompt for a student ID
            int id = int.Parse(ConsoleIO.Prompt("Enter student ID: ",true));
            StudentManager manager = StudentManagerFactory.Create();
            Response<Student> response = manager.GetStudentById(id);
            if (response.Success)
            {
                Student student = response.Data;
                ConsoleIO.Display($"Name: {student.Name}\nGPA: {student.GPA}");
                if (ConsoleIO.Prompt("Would you like to delete this student? Y/N") == "Y")
                {
                    response = manager.DeleteStudent(student.Id);
                    if (response.Success)
                    {
                        ConsoleIO.Display("This student has been deleted.");
                    }
                    else
                    {
                        ConsoleIO.Display(response.Message);
                    }
                }
                else
                {
                    ConsoleIO.Display(response.Message);
                }
            }
            //If student exist display the student information
            //Ask if they would like to delete this student Y/n
            //If y, call delete. ON success display message.
            //If student does not exist, display error

        }
    }
}