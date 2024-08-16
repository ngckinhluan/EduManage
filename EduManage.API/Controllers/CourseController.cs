using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            var result = service.GetAllCourses();
            var response = mapper.Map<List<CourseResponseDto>>(result);
            return Ok(response);
        }

        [HttpGet("GetCourseById/{id}")]
        public IActionResult GetCourse(int id)
        {
            var result = service.GetCourseById(id);
            if (result == null)
            {
                return NotFound(new { message = $"Course with id: {id} is not found! " });
            }
            var response = mapper.Map<CourseResponseDto>(result);
            return Ok(response);
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse(CourseRequestDto course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid model state!",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            try
            {
                service.AddCourse(course);
                return Ok(new { message = "Course added successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while adding the student!",
                    error = ex.Message
                });
            }
        }

        [HttpPut("UpdateCourse/{id}")]
        public IActionResult UpdateCourse(int id, CourseRequestDto course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid model state!",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var existingCourse = service.GetCourseById(id);
            if (existingCourse == null)
            {
                return NotFound(new { message = $"Course with id: {id} not found!" });
            }

            try
            {
                service.UpdateCourse(id, course);
                return Ok(new { message = "Course updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating the course!",
                    error = ex.Message
                });
            }
        }



        [HttpDelete("DeleteCourse/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = service.GetCourseById(id);
            if (course == null)
            {
                return NotFound(new { message = $"Student with id: {id} not found!" });
            }
            try
            {
                service.DeleteCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the student!", error = ex.Message });
            }
        }
    }
}
