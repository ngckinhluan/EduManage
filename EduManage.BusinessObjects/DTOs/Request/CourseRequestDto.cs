using System.ComponentModel.DataAnnotations;

namespace EduManage.BusinessObjects.DTOs.Request;

public class CourseRequestDto
{
    public string? CourseName { get; set; }
    public string? Description { get; set; }
    public required int Credit { get; set; }
    public string? InstructorName { get; set; }
}