﻿using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController(ICourseService service, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses()
        {
            var result = service.GetAllCourses();
            var response = mapper.Map<List<CourseResponseDto>>(result);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "CourseById")]
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

        [HttpPost]
        public IActionResult AddCourse([FromBody] CourseRequestDto course)
        {
            service.AddCourse(course);
            return Ok(new { message = "Course added successfully!" });
        }
        
        [HttpPost]
        public IActionResult FindCourse([FromBody] Func<Course, bool> predicate)
        {
            var result = service.Find(predicate);
            if (result == null)
            {
                return NotFound(new { message = "Course not found! " });
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseRequestDto course)
        {
            var existingCourse = service.GetCourseById(id);
            if (existingCourse == null)
            {
                return NotFound(new { message = $"Course with id: {id} not found!" });
            }
            service.UpdateCourse(id, course);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = service.GetCourseById(id);
            if (course == null)
            {
                return NotFound(new { message = $"Student with id: {id} not found!" });
            }
            service.DeleteCourse(id);
            return NoContent();
        }
        
        
    }
}