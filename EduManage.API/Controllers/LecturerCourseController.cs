using Microsoft.AspNetCore.Mvc;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Authorization;

namespace EduManage.API.Controllers
{
    [Route("api/lecturerCourse")]
    [ApiController]
    public class LecturerCourseController(ILecturerCourseService lecturerCourseService) : ControllerBase
    {
        [HttpGet]
        [Authorize (Roles = "4")]

        public IActionResult GetLecturerCourses()
        {
            var result = lecturerCourseService.GetAllLecturerCourses();
            return Ok(result);
        }

        [HttpGet("{lecturerId}/{courseId}")]
        [Authorize (Roles = "4")]

        public IActionResult GetLecturerCourse(int lecturerId, int courseId)
        {
            var result = lecturerCourseService.GetLecturerCourseById(lecturerId, courseId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize (Roles = "4")]

        public IActionResult AddLecturerCourse([FromBody] LecturerCourseRequestDto lecturerCourse)
        {
            lecturerCourseService.AddLecturerCourse(lecturerCourse);
            return Ok(new { message = "LecturerCourse added successfully!" });
        }

        // [HttpPost("find")]
        // public IActionResult FindLecturerCourse([FromBody] Func<LecturerCourse, bool> predicate)
        // {
        //     var result = lecturerCourseService.Find(predicate);
        //     return Ok(result);
        // }

        [HttpPut("{lecturerId}/{courseId}")]
        [Authorize (Roles = "4")]

        public IActionResult UpdateLecturerCourse(int lecturerId, int courseId,
            [FromBody] LecturerCourseRequestDto lecturerCourse)
        {
            lecturerCourseService.UpdateLecturerCourse(lecturerId, courseId, lecturerCourse);
            return Ok(new { message = "LecturerCourse updated successfully!" });
        }

        [HttpDelete("{lecturerId}/{courseId}")]
        [Authorize (Roles = "4")]

        public IActionResult DeleteLecturerCourse(int lecturerId, int courseId)
        {
            lecturerCourseService.DeleteLecturerCourse(lecturerId, courseId);
            return NoContent();
        }
    }
}