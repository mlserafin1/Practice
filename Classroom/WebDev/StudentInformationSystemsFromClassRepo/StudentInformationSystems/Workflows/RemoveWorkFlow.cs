using System;
using StudentInformationSystems.BLL;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Workflows
{
    public class RemoveWorkFlow : IWorkFlow
    {
        public void Execute()
        {
            //Promopt the user for a student ID
            int id = ConsoleIO.PromptInt("Enter Student Id");
            StudentManager manager = StudentManagerFactory.SetupManager();
            Response<Student> response = manager.GetStudentById(id);
            //If Student exist we should display the student infomationX
            if (response.Success)
            {
                Student student = response.Data;
                ConsoleIO.Display($"Name: {student.Name}\nGPA:{student.GPA}");
                //Ask if they would like to delete this student Y/N
                if (ConsoleIO.Prompt("Would you like to delete this student? Y/N") == "Y")
                {
                   response = manager.DeleteStudent(student.Id);
                    if (response.Success)
                    {
                        ConsoleIO.Display("The student has been deleted");
                    }
                    else
                    {
                        ConsoleIO.Display(response.Message);
                    }
                }
                //If Y, call delete. ON success display message

            }
            else
            {
                ConsoleIO.Display(response.Message);
            }
            
            //If Student does not exist, we should display an error
          
        }
    }
}