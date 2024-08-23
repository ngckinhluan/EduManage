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
    [Route("api/lecturer")]
    [ApiController]
    public class LecturerController(ILecturerService service) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLecturers()
        {
            var result = service.GetAll();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetLecturer(int id)
        {
            var result = service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddLecturer([FromBody] LecturerRequestDto lecturer)
        {
            service.Add(lecturer);
            return Ok(new { message = "Lecturer added successfully!" });
        }

        [HttpPost("find")]
        public IActionResult FindLecturer([FromBody] Func<Lecturer, bool> predicate)
        {
            var result = service.Find(predicate);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLecturer(int id, [FromBody] LecturerRequestDto lecturer)
        {
            var existingLecturer = service.GetById(id);
            service.Update(id, lecturer);
            return Ok(new { message = "Lecturer updated successfully!" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLecturer(int id)
        {
            var lecturer = service.GetById(id);
            service.Delete(id);
            return Ok(new { message = "Lecturer deleted successfully!" });
        }
    }
}
