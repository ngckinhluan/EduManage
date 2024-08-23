namespace EduManage.BusinessObjects.DTOs.Request;

public class LecturerCourseRequestDto
{
    public DateOnly? AssignedDate { get; set; }
    public string? Role { get; set; }
}