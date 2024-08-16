using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation
{
    public class CourseService(ICourseRepository repository, IMapper mapper) : ICourseService
    {

        public List<Course> GetAllCourses()
        {
            return repository.GetAll();
        }

        public Course GetCourseById(int id)
        {
            return repository.GetById(id);
        }

        public void AddCourse(CourseRequestDto course)
        {
            var entity = mapper.Map<Course>(course);
            repository.Add(entity);
        }

        public void UpdateCourse(int id, CourseRequestDto course)
        {
            repository.Update(id, mapper.Map<Course>(course));
        }

        public void DeleteCourse(int id)
        {
            repository.Delete(id);
        }
    }
}
