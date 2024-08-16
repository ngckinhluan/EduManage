namespace EduManage.BusinessObjects.DTOs.Response;

public class StudentResponseDto
{
    public required int StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string Email { get; set; }    
    public string? Phone { get; set; }
    public string? Address { get; set; }
}