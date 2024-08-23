using EduManage.BusinessObjects.Entities;

namespace EduManage.BusinessObjects.DTOs.Request;

public class RoleRequestDto
{
    public RoleName RoleName { get; set; }
    public string? Description { get; set; }
}