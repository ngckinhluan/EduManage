using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController(ICourseService service, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Authorize (Roles = "4")]
        public IActionResult GetCourses()
        {
            var result = service.GetAllCourses();
            var response = mapper.Map<List<CourseResponseDto>>(result);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "CourseById")]
        [Authorize (Roles = "4")]
        public IActionResult GetCourse(int id)
        {
            var result = service.GetCourseById(id);
            var response = mapper.Map<CourseResponseDto>(result);
            return Ok(response);
        }

        [HttpPost]
        [Authorize (Roles = "4")]
        public IActionResult AddCourse([FromBody] CourseRequestDto course)
        {
            service.AddCourse(course);
            return Ok(new { message = "Course added successfully!" });
        }
        
        // [HttpPost("find")]
        // public IActionResult FindCourse([FromBody] Func<Course, bool> predicate)
        // {
        //     var result = service.Find(predicate);
        //     return Ok(result);
        // }

        [HttpPut("{id}")]
        [Authorize (Roles = "4")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseRequestDto course)
        {
            var existingCourse = service.GetCourseById(id);
            service.UpdateCourse(id, course);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize (Roles = "4")]
        public IActionResult DeleteCourse(int id)
        {
            var course = service.GetCourseById(id);
            service.DeleteCourse(id);
            return NoContent();
        }
        
        
    }
}