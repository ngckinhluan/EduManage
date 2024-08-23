﻿namespace EduManage.BusinessObjects.DTOs.Request;

public class LecturerRequestDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public int? RoleId { get; set; }
}