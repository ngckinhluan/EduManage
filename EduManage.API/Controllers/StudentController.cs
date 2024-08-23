using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController(IStudentService service, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var result = service.GetAll();
            var response = mapper.Map<List<StudentResponseDto>>(result);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var result = service.GetById(id);
            var response = mapper.Map<StudentResponseDto>(result);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentRequestDto student)
        {
            service.Add(student);
            return Ok(new { message = "Student added successfully!" });
        }

        // [HttpPost("find")]
        // public IActionResult FindStudent([FromBody] Func<Student, bool> predicate)
        // {
        //     var result = service.Find(predicate);
        //     return Ok(result);
        // }


        //[HttpPut("UpdateStudent")]
        //public IActionResult UpdateStudent([FromBody] StudentRequestDto student)
        //{
        //    service.Update(student);
        //    return Ok(new { message = "Student updated successfully!" });
        //}

        //[HttpDelete("DeleteStudent/{id}")]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = service.GetById(id);
        //    if (student == null)
        //    {
        //        return NotFound(new { message = $"Student with id: {id} not found!" });
        //    }
        //    try
        //    {
        //        service.Delete(id);
        //        return NoContent(); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "An error occurred while deleting the student!", error = ex.Message });
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentRequestDto student)
        { 
            service.Update(id, student);
            return Ok(new { message = "Student updated successfully!" });
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = service.GetById(id);
            service.Delete(id);
            return Ok(new { message = "Student deleted successfully!" });
        }
    }
}