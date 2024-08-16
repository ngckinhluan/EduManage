using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Services.Interface
{
    public interface IEnrollmentService
    {
        List<Enrollment> GetAllEnrollments();
        Enrollment GetEnrollmentById(int studentId, int courseId);
        void AddEnrollment(EnrollmentRequestDto enrollment);
        void UpdateEnrollment(int studentId, int courseId, EnrollmentRequestDto enrollment);
        void DeleteEnrollment(int studentId, int courseId);
    }
}
