using System.ComponentModel.DataAnnotations;

namespace EduManage.BusinessObjects.Entities;

public class Lecturer
{
    public required int LecturerId { get; set; }
    [StringLength(255)]
    public required string UserName { get; set; }
    [EmailAddress]
    [StringLength(255)]
    public required string Email { get; set; }
    [StringLength(255)]
    public required string Password { get; set; }
    [StringLength(255)]
    public required string FirstName { get; set; }
    [StringLength(255)]
    public required string LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    
    // Navigation property
    public virtual ICollection<LecturerCourse>? LecturerCourses { get; set; }
}