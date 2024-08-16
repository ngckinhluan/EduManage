using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController(IEnrollmentService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("GetEnrollments")]
        public IActionResult GetEnrollments()
        {
            var result = service.GetAllEnrollments();
            if (result == null)
            {
                return NotFound(new { message = "Enrollment not found! " });
            }
            return Ok(result);
        }

        [HttpGet("GetEnrollmentById/{studentId}/{courseId}")]
        public IActionResult GetEnrollment(int studentId, int courseId)
        {
            var result = service.GetEnrollmentById(studentId, courseId);
            if (result == null)
            {
                return NotFound(new { message = $"Enrollment with studentId: {studentId} and courseId: {courseId} is not found!" });
            }
            return Ok(result);
        }

        [HttpPost("AddEnrollment")]
        public IActionResult AddEnrollment(EnrollmentRequestDto enrollment)
        {
            service.AddEnrollment(enrollment);
            return Ok(new { message = "Enrollment added successfully!" });
        }

        //[HttpPut("UpdateEnrollment")]
        //public IActionResult UpdateEnrollment(EnrollmentRequestDto enrollment)
        //{
        //    service.UpdateEnrollment(enrollment);
        //    return Ok(new { message = "Enrollment updated successfully!" });
        //}

        [HttpPut("UpdateEnrollment/{studentId}/{courseId}")]
        public IActionResult UpdateEnrollment(int studentId, int courseId, EnrollmentRequestDto enrollment)
        {
            service.UpdateEnrollment(studentId, courseId, enrollment);
            return Ok(new { message = "Enrollment updated successfully!" });
        }

        [HttpDelete("DeleteEnrollment/{studentId}/{courseId}")]
        public IActionResult DeleteEnrollment(int studentId, int courseId)
        {
            service.DeleteEnrollment(studentId, courseId);
            return Ok(new { message = "Enrollment deleted successfully!" });
        }

    }
}
