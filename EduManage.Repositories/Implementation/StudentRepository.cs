using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;
using EduManage.Repositories.Interface;

namespace EduManage.Repositories.Implementation
{
    public class StudentRepository(StudentDao studentDao) : IStudentRepository
    {
        public List<Student> GetAll()
        {
            return studentDao.GetStudents();
        }

        public Student GetById(int id)
        {
            return studentDao.GetStudentById(id);
        }

        public void Add(Student entity)
        {
            studentDao.AddStudent(entity);
        }

        public void Update(int id, Student entity)
        {
            studentDao.UpdateStudent(id, entity);
        }

        public void Delete(int id)
        {
            studentDao.DeleteStudent(id);
        }

        public List<Student> Find(Func<Student, bool> predicate)
        {
            return studentDao.Find(predicate);
        }

        public Student GetStudentByEmail(string email)
        {
            return studentDao.GetStudentByEmail(email);
        }
    }
}
