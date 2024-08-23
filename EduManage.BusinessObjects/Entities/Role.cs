using System.ComponentModel.DataAnnotations;

namespace EduManage.BusinessObjects.Entities;

public class Role
{
    public int RoleId { get; set; }
    public RoleName RoleName { get; set; }
    [StringLength(255)]
    public string? Description { get; set; }
    
    // Navigation properties
    public virtual ICollection<Lecturer>? Lectures { get; set; }
}