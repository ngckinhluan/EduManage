namespace EduManage.BusinessObjects.DTOs.Response;

public class CourseResponseDto
{
    public required int CourseId { get; set; }
    public required string CourseName { get; set; }
    public string? Description { get; set; }
    public required int Credit { get; set; }
    public string? InstructorName { get; set; }
}