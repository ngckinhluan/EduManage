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
    public class CourseRepository(CourseDao courseDao) : ICourseRepository
    {
        
        public List<Course> GetAll() => courseDao.GetCourses();
        public Course GetById(int id) => courseDao.GetCourseById(id);
        public void Add(Course entity) =>  courseDao.AddCourse(entity);
        public void Update(int id, Course entity) => courseDao.UpdateCourse(id, entity);
        public void Delete(int id) => courseDao.DeleteCourse(id);
        public List<Course> Find(Func<Course, bool> predicate) => courseDao.Find(predicate);

    }
}
