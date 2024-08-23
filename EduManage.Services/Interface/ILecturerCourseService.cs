using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Services.Interface;

public interface ILecturerCourseService
{
    List<LecturerCourse> GetAllLecturerCourses();
    LecturerCourse GetLecturerCourseById(int lecturerId, int courseId);
    void AddLecturerCourse(LecturerCourseRequestDto lecturerCourse);
    void UpdateLecturerCourse(int lecturerId, int courseId, LecturerCourseRequestDto lecturerCourse);
    void DeleteLecturerCourse(int lecturerId, int courseId);
    List<LecturerCourse> Find(Func<LecturerCourse, bool> predicate);
    
}