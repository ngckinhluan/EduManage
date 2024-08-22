using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;
using EduManage.Repositories.Interface;

namespace EduManage.Repositories.Implementation;

public class LecturerCourseRepository(LecturerCourseDao lecturerCourseDao) : ILecturerCourseRepository
{
    public List<LecturerCourse> GetAll() => lecturerCourseDao.GetLecturerCourses();
    public LecturerCourse GetById(int lecturerId, int courseId) => lecturerCourseDao.GetLecturerCourseById(lecturerId, courseId);
    public void Add(LecturerCourse entity) => lecturerCourseDao.AddLecturerCourse(entity);
    public void Update(int lecturerId, int courseId, LecturerCourse entity) => lecturerCourseDao.UpdateLecturerCourse(lecturerId, courseId, entity);
    public void Delete(int lecturerId, int courseId) => lecturerCourseDao.DeleteLecturerCourse(lecturerId, courseId);
    public void Find(Func<LecturerCourse, bool> predicate) => lecturerCourseDao.Find(predicate);

}