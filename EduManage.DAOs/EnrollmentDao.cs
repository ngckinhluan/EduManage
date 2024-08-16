using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduManage.DAOs
{
    public class EnrollmentDao(ApplicationDbContext context)
    {
        public List<Enrollment> GetEnrollments()
        {
            return context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .AsNoTracking()
                .ToList();
        }

        public Enrollment GetEnrollmentById(int studentId, int courseId)
        {
            return context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .AsNoTracking()
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
        }

        public void UpdateEnrollment(int studentId, int courseId, Enrollment updatedEnrollment)
        {
            var existingEnrollment = context.Enrollments
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
            if (existingEnrollment == null)
            {
                throw new Exception("Enrollment not found");
            }

            existingEnrollment.Grade = updatedEnrollment.Grade;
            existingEnrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;
            context.SaveChanges();

        }

        public void DeleteEnrollment(int studentId, int courseId)
        {
            var enrollment = context.Enrollments.Find(studentId, courseId);
            context.Enrollments.Remove(enrollment);
            context.SaveChanges();
        }
    }
}
