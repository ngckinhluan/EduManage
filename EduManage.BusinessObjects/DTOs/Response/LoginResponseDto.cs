namespace EduManage.BusinessObjects.DTOs.Response;

public class LoginResponseDto
{
    public string? Token { get; set; }
    public DateTime? Expiration { get; set; }
}