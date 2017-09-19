using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystems.Data;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.BLL
{
    public class StudentManager
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Response<Student> AddStudent(Student student)
        {
            Response<Student> response = new Response<Student>();
            try
            {
                _studentRepository.AddStudent(student);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<Student> UpdateStudent(Student student)
        {
            Response<Student> response = new Response<Student>();
            try
            {
                _studentRepository.UpdateStudent(student);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<Student> DeleteStudent(int id)
        {
            Response<Student> response = new Response<Student>();
            try
            {
                if (_studentRepository.GetStudentById(id) == null)
                {
                    throw new Exception("Student not found");
                }
                _studentRepository.Delete(id);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<IEnumerable<Student>> GetStudents()
        {
            Response<IEnumerable<Student>> response = new Response<IEnumerable<Student>>();
            try
            {
                response.Data = _studentRepository.GetStudents();
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
