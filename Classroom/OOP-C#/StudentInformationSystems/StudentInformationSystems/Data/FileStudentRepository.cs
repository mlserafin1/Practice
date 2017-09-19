using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentInformationSystems.BLL;
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
            using (StreamWriter sw = new StreamWriter(_filename, true))
            {
                sw.WriteLine("{0},{1},{2}", student.Id, student.Name, student.GPA);
            }
            
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            //load list of students
            List<Student> students = Load();
            //find student by ID
            Student student = students.Find(a => a.Id == id);
            //remove from list
            students.Remove(student);
            //save the list
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
            result = students.FirstOrDefault(s=>s.Id == id);
            if (result == null)
            {
                throw new Exception("Student ID does not exist.");
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
                    Student student = new Student();

                    string[] fields = line.Split(',');
                    
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
            using (StreamWriter sw = new StreamWriter(_filename,false))
            {
                sw.WriteLine("ID,Name,GPA");
                foreach (var student in students)
                {
                    sw.WriteLine("{0},{1},{2}", student.Id, student.Name, student.GPA);
                }
            }

        }
    }
}