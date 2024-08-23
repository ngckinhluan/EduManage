namespace EduManage.BusinessObjects.DTOs.Request;

public class RegisterRequestDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; } 
    public string? Username { get; set; }
}