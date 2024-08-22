using EduManage.BusinessObjects.Entities;

namespace EduManage.BusinessObjects.DTOs.Response;

public class LecturerCourseResponseDto
{
    public required int LecturerId { get; set; }
    public required int CourseId { get; set; }
    public DateOnly? AssignedDate { get; set; }
    public string? Role { get; set; }
    
    public virtual Lecturer? Lecturer { get; set; }
    public virtual Course? Course { get; set; }
}