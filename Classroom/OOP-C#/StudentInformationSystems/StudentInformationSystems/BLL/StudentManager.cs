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
                Student student = _studentRepository.GetStudentById(id);
                _studentRepository.Delete(student.Id);
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

        public Response<Student> GetStudentById(int id)
        {
            Response<Student> result = new Response<Student>();
            try
            {
                result.Data = _studentRepository.GetStudentById(id);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
    }
}
