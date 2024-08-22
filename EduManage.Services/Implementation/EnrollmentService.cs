using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation
{
    public class EnrollmentService(IEnrollmentRepository repository, IMapper mapper) : IEnrollmentService
    {
        public List<Enrollment> GetAllEnrollments() => repository.GetAll();
        // public List<Enrollment> Find(Func<Enrollment, bool> predicate)
        // {
        //     return repository.Find(predicate);
        // }
        public Enrollment GetEnrollmentById(int studentId, int courseId) => repository.GetById(studentId, courseId);
        public void AddEnrollment(EnrollmentRequestDto enrollment)
        {
            var entity = mapper.Map<Enrollment>(enrollment);
            repository.Add(entity);
        }
        public void UpdateEnrollment(int studentId, int courseId, EnrollmentRequestDto enrollment) => repository.Update(studentId, courseId, mapper.Map<Enrollment>(enrollment));
        public void DeleteEnrollment(int studentId, int courseId) =>  repository.Delete(studentId, courseId);
    }
}
