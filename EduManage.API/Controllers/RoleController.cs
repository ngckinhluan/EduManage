using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers;

[Route("api/role")]
[ApiController]
public class RoleController(IRoleService service, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [Authorize (Roles = "4")]
    
    public IActionResult GetRoles()
    {
        var result = service.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [Authorize (Roles = "4")]

    public IActionResult GetRole(int id)
    {
        var result = service.GetById(id);
        return Ok(result);
    }
    // public IActionResult AddRole([FromBody] RoleRequestDto roleDto)
    // {
    //     if (!Enum.IsDefined(typeof(Role), roleDto.RoleName))
    //     {
    //         return BadRequest(new { message = "Invalid role specified!" });
    //     }
    //     service.Add(roleDto);
    //     return Ok(new { message = "Role added successfully!" });
    // }
    [HttpPost]
    [Authorize (Roles = "4")]

    public IActionResult AddRole([FromBody] RoleRequestDto roleDto)
    {
        if (!Enum.IsDefined(typeof(RoleName), roleDto.RoleName))
        {
            return BadRequest(new { message = "Invalid role specified!" });
        }
        service.Add(roleDto); 
        return Ok(new { message = "Role added successfully!" });
    }

    
    [HttpPut("{id}")]
    [Authorize (Roles = "4")]

    public IActionResult UpdateRole(int id, [FromBody] RoleRequestDto role)
    {
        service.Update(id, role);
        return Ok(new { message = "Role updated successfully!" });
    }
    
    [HttpDelete("{id}")]
    [Authorize (Roles = "4")]
    public IActionResult DeleteRole(int id)
    {
        service.Delete(id);
        return NoContent();
    }
    
}