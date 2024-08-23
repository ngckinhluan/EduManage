using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation;

public class LecturerCourseService(ILecturerCourseRepository lecturerCourseRepository, IMapper mapper)
    : ILecturerCourseService
{
    public List<LecturerCourse> GetAllLecturerCourses() => lecturerCourseRepository.GetAll();
    public LecturerCourse GetLecturerCourseById(int lecturerId, int courseId) => lecturerCourseRepository.GetById(lecturerId, courseId);
    public void AddLecturerCourse(LecturerCourseRequestDto lecturerCourse) => lecturerCourseRepository.Add(mapper.Map<LecturerCourse>(lecturerCourse));
    public void UpdateLecturerCourse(int lecturerId, int courseId, LecturerCourseRequestDto lecturerCourse) => lecturerCourseRepository.Update(lecturerId, courseId, mapper.Map<LecturerCourse>(lecturerCourse));
    public void DeleteLecturerCourse(int lecturerId, int courseId) => lecturerCourseRepository.Delete(lecturerId, courseId);
    public List<LecturerCourse> Find(Func<LecturerCourse, bool> predicate) => lecturerCourseRepository.Find(predicate);
}