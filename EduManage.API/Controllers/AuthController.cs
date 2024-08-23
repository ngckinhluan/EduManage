using EduManage.BusinessObjects.DTOs.Request;
using EduManage.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EduManage.API.Controllers;
[ApiController]
[Route("api/authentication")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
    {
        try
        {
            var response = authService.Login(loginRequestDto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequestDto registerRequestDto)
    {
        try
        {
            authService.Register(registerRequestDto);
            return Ok(new { message = "Registration successful" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("forgot-password")]
    public IActionResult ForgotPassword([FromBody]ForgotPasswordRequestDto forgotPasswordRequestDto)
    {
        try
        {
            authService.ForgotPassword(forgotPasswordRequestDto.Email);
            return Ok(new { message = "Password reset instructions sent to your email" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}