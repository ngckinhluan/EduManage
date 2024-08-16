namespace EduManage.BusinessObjects.DTOs.Request;

public class EnrollmentRequestDto
{
    public required int StudentId { get; set; }
    public required int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string? Grade { get; set; }
}