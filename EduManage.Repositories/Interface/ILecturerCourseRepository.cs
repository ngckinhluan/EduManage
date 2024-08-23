using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface.GenericRepository;

namespace EduManage.Repositories.Interface;

public interface ILecturerCourseRepository 
{
    List<LecturerCourse> GetAll();
    LecturerCourse GetById(int lecturerId, int courseId);
    void Add(LecturerCourse entity);
    void Update(int lecturerId, int courseId, LecturerCourse entity);
    void Delete(int lecturerId, int courseId);
    List<LecturerCourse> Find (Func<LecturerCourse, bool> predicate);
    
}