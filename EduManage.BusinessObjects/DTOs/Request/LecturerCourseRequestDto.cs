namespace EduManage.BusinessObjects.DTOs.Request;

public class LecturerCourseRequestDto
{
    public required int LecturerId { get; set; }
    public required int CourseId { get; set; }
    public DateOnly? AssignedDate { get; set; }
    public string? Role { get; set; }
}