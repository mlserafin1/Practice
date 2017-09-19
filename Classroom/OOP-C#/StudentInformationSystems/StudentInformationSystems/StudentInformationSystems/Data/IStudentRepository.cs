using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Data
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void Delete(int id);
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
    }
}
