using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var id = 1;
            var students = Load();
            if (students.Any())
            {
                id += students.Max(r => r.Id);

            }
            student.Id = id;
            students.Add(student);
            Save(students);
        }

        public void UpdateStudent(Student student)
        {
            var students = Load();
            students.Remove(students.FirstOrDefault(r => r.Id == student.Id));
            students.Add(student);

            Save(students);
        }

        public void Delete(int id)
        {
            // Load the list of students
            List<Student> students = Load();
            // find the student by Id
            Student student = students.Find(r=> r.Id == id);
            // remove from list
            students.Remove(student);
            // save the list
            Save(students);
        }

        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> results;
            results = Load();
            return results;
        }

        public Student GetStudentById(int id)
        {
            Student result;
            List<Student> students = Load();
            result = students.FirstOrDefault(s => s.Id == id);
            if (result == null)
            {
                throw  new Exception("Student Id does not exist");
            }
            return result;
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
            using (StreamWriter sw = new StreamWriter(_filename))
            {
                sw.WriteLine("Id,Name,GPA");
                foreach (var student in students)
                {
                    sw.WriteLine($"{student.Id},{student.Name},{student.GPA}");
                }
            }

        }
    }
}