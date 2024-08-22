
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Services.Interface
{
    public interface IEnrollmentService
    {
        List<Enrollment> GetAllEnrollments();
        // List<Enrollment> Find(Func<Enrollment, bool> predicate);
        Enrollment GetEnrollmentById(int studentId, int courseId);
        void AddEnrollment(EnrollmentRequestDto enrollment);
        void UpdateEnrollment(int studentId, int courseId, EnrollmentRequestDto enrollment);
        void DeleteEnrollment(int studentId, int courseId);

    }
}
