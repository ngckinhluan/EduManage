using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduManage.BusinessObjects.Context;
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
            if (result == null)
            {
                return NotFound(new { message = "LecturerCourse not found! " });
            }
            return Ok(result);
        }
       
        [HttpGet("{id}")]
        public IActionResult GetLecturerCourse(int lecturerId, int courseId)
        {
            var result = lecturerCourseService.GetLecturerCourseById(lecturerId, courseId);
            if (result == null)
            {
                return NotFound(new { message = $"LecturerCourse with lecturerId: {lecturerId} and courseId: {courseId} is not found!" });
            }

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
            if (result == null)
            {
                return NotFound(new { message = "LecturerCourse not found! " });
            }

            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateLecturerCourse(int lecturerId, int courseId, [FromBody] LecturerCourseRequestDto lecturerCourse)
        {
            var existingLecturerCourse = lecturerCourseService.GetLecturerCourseById(lecturerId, courseId);
            if (existingLecturerCourse == null)
            {
                return NotFound(new { message = $"LecturerCourse with lecturerId: {lecturerId} and courseId: {courseId} not found!" });
            }
            lecturerCourseService.UpdateLecturerCourse(lecturerId, courseId, lecturerCourse);
            return Ok(new { message = "LecturerCourse updated successfully!" });
        }
        
        [HttpDelete("{lecturerId}/{courseId}")]
        public IActionResult DeleteLecturerCourse(int lecturerId, int courseId)
        {
            var lecturerCourse = lecturerCourseService.GetLecturerCourseById(lecturerId, courseId);
            if (lecturerCourse == null)
            {
                return NotFound(new { message = $"LecturerCourse with lecturerId: {lecturerId} and courseId: {courseId} not found!" });
            }
            try
            {
                lecturerCourseService.DeleteLecturerCourse(lecturerId, courseId);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the lecturerCourse!", error = ex.Message });
            }
        }
    }
}
