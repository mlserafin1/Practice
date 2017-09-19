using System;
using System.Collections.Generic;
using System.IO;
using StudentInformationSystems.Models;

namespace StudentInformationSystems.Data
{
    public class FileStudentRepository : IStudentRepository
    {
        private  string _filename;

        public FileStudentRepository(string filename)
        {
            _filename = filename;
        }
        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> results;
            results = Load();
            return results;
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        private List<Student> Load()
        {
            //Set a return variable that is an empty list
            List<Student> results = new List<Student>();
            using (StreamReader sr = new StreamReader(_filename))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    Student student = new Student();
                    student.Id = int.Parse(fields[0]);
                    student.Name = fields[1];
                    student.GPA = decimal.Parse(fields[2]);
                    results.Add(student);
                }

            }
            return results;
        }

        private void Save(IEnumerable<Student> students)
        {
            throw new NotImplementedException();

        }
    }
}