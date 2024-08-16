using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService service, IMapper mapper) : ControllerBase
    {
        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            var result = service.GetAll();
            var response = mapper.Map<List<StudentResponseDto>>(result);
            return Ok(response);
        }


        [HttpGet("GetStudentById/{id}")]
        public IActionResult GetStudent(int id)
        {
            var result = service.GetById(id);
            if (result == null)
            {
                return NotFound(new { message = $"Student with id: {id} is not found!" });
            }
            var response = mapper.Map<StudentResponseDto>(result);
            return Ok(response);
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] StudentRequestDto student)
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
                service.Add(student);
                return Ok(new { message = "Student added successfully!" });
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

        [HttpPut("UpdateStudent/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentRequestDto student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    message = "Invalid model state!",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }
            var existingStudent = service.GetById(id);
            if (existingStudent == null)
            {
                return NotFound(new { message = $"Student with id: {id} not found!" });
            }

            try
            {
                service.Update(id, student);
                return Ok(new { message = "Student updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the student!", error = ex.Message });
            }
        }
    }
}
