using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;

namespace EduManage.DAOs
{
    public class StudentDao(ApplicationDbContext context)
    {
        //public StudentDao()
        //{
        //    if (_context == null)
        //    {
        //        _context = new ApplicationDbContext();
        //    }
        //}

        public List<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return context.Students.Find(studentId) ?? throw new InvalidOperationException();
        }

        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void UpdateStudent(int id, Student student)
        {
            var existingStudent = context.Students.Find(id);
            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.Address = student.Address;
            existingStudent.DateOfBirth = student.DateOfBirth;
            context.Students.Update(student);
            context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = context.Students.Find(studentId);
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public Student? GetStudentByEmail(string email)
        {
            return context.Students.FirstOrDefault(s => s.Email == email);
        }

        public List<Student> Find(Func<Student, bool> predicate)
        {
            return context.Students.Where(predicate).ToList();
        }
    }
}