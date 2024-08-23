using Microsoft.AspNetCore.Mvc;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;

namespace EduManage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerCourseController(ILecturerCourseService lecturerCourseService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLecturerCourses()
        {
            var result = lecturerCourseService.GetAllLecturerCourses();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetLecturerCourse(int lecturerId, int courseId)
        {
            var result = lecturerCourseService.GetLecturerCourseById(lecturerId, courseId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddLecturerCourse([FromBody] LecturerCourseRequestDto lecturerCourse)
        {
            lecturerCourseService.AddLecturerCourse(lecturerCourse);
            return Ok(new { message = "LecturerCourse added successfully!" });
        }

        [HttpPost]
        public IActionResult FindLecturerCourse([FromBody] Func<LecturerCourse, bool> predicate)
        {
            var result = lecturerCourseService.Find(predicate);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLecturerCourse(int lecturerId, int courseId,
            [FromBody] LecturerCourseRequestDto lecturerCourse)
        {
            var existingLecturerCourse = lecturerCourseService.GetLecturerCourseById(lecturerId, courseId);
            lecturerCourseService.UpdateLecturerCourse(lecturerId, courseId, lecturerCourse);
            return Ok(new { message = "LecturerCourse updated successfully!" });
        }

        [HttpDelete("{lecturerId}/{courseId}")]
        public IActionResult DeleteLecturerCourse(int lecturerId, int courseId)
        {
            lecturerCourseService.DeleteLecturerCourse(lecturerId, courseId);
            return NoContent();
        }
    }
}