using System.Collections.Generic;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Data
{
    public class TestStudentRepository : IStudentRepository
    {
        public void AddStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}