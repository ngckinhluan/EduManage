using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;

namespace EduManage.DAOs
{
    public class CourseDao(ApplicationDbContext context)
    {
        public List<Course> GetCourses()
        {
            return context.Courses.ToList();
        }

        public Course GetCourseById(int courseId)
        {
            return context.Courses.Find(courseId);
        }

        public void AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            var course = context.Courses.Find(courseId);
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public void UpdateCourse(int id, Course course)
        {
            var existingCourse = context.Courses.Find(id);
            if (existingCourse == null)
            {
                throw new Exception("Course not found");
            }
            existingCourse.CourseName = course.CourseName;
            existingCourse.Credit = course.Credit;
            existingCourse.InstructorName = course.InstructorName;
            existingCourse.Description = course.Description;
            context.Courses.Update(course);
            context.SaveChanges();
        }


    }
}
