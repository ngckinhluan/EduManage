using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Services.Interface
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(CourseRequestDto course);
        void UpdateCourse(int id, CourseRequestDto course);
        void DeleteCourse(int id);
    }
}
