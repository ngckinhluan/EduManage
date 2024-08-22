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
    public class EnrollmentRepository(EnrollmentDao enrollmentDao) : IEnrollmentRepository
    { 
        public List<Enrollment> GetAll() => enrollmentDao.GetEnrollments();
        public Enrollment GetById(int studentId, int courseId) => enrollmentDao.GetEnrollmentById(studentId, courseId);
        public void Add(Enrollment entity) => enrollmentDao.AddEnrollment(entity);
        public void Update(int studentId, int courseId, Enrollment entity) => enrollmentDao.UpdateEnrollment(studentId, courseId, entity);
        public void Delete(int studentId, int courseId) => enrollmentDao.DeleteEnrollment(studentId, courseId);
        public void Find(Func<Enrollment, bool> predicate) => enrollmentDao.Find(predicate);
    }
}