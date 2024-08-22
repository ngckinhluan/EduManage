using System.ComponentModel.DataAnnotations;

namespace EduManage.BusinessObjects.Entities;

public class LecturerCourse
{
    public required int LecturerId { get; set; }
    public required int CourseId { get; set; }
    public DateOnly? AssignedDate { get; set; }
    [MaxLength(50)]
    public string? Role { get; set; }
    
    // Navigation property
    public virtual Lecturer? Lecturer { get; set; }
    public virtual Course? Course { get; set; }
}