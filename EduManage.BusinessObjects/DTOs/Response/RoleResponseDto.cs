using EduManage.BusinessObjects.Entities;

namespace EduManage.BusinessObjects.DTOs.Response;

public class RoleResponseDto
{
    public int RoleId { get; set; }
    public RoleName RoleName { get; set; }
    public string? Description { get; set; }

}