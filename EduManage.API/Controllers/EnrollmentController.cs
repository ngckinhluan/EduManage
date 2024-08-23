using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController(IEnrollmentService service, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var result = service.GetAllEnrollments();
            return Ok(result);
        }

        [HttpGet("{studentId}/{courseId}")]
        public IActionResult GetEnrollment(int studentId, int courseId)
        {
            var result = service.GetEnrollmentById(studentId, courseId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddEnrollment(EnrollmentRequestDto enrollment)
        {
            service.AddEnrollment(enrollment);
            return Ok(new { message = "Enrollment added successfully!" });
        }
        
        // [HttpPost("find")]
        // public IActionResult FindEnrollment([FromBody] Func<Enrollment, bool> predicate)
        // {
        //     var result = service.Find(predicate);
        //     return Ok(result);
        // }

        //[HttpPut("UpdateEnrollment")]
        //public IActionResult UpdateEnrollment(EnrollmentRequestDto enrollment)
        //{
        //    service.UpdateEnrollment(enrollment);
        //    return Ok(new { message = "Enrollment updated successfully!" });
        //}

        [HttpPut("{studentId}/{courseId}")]
        public IActionResult UpdateEnrollment(int studentId, int courseId, EnrollmentRequestDto enrollment)
        {
            service.UpdateEnrollment(studentId, courseId, enrollment);
            return Ok(new { message = "Enrollment updated successfully!" });
        }

        [HttpDelete("{studentId}/{courseId}")]
        public IActionResult DeleteEnrollment(int studentId, int courseId)
        {
            service.DeleteEnrollment(studentId, courseId);
            return Ok(new { message = "Enrollment deleted successfully!" });
        }

    }
}
