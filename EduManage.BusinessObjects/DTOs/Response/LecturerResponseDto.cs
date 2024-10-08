﻿namespace EduManage.BusinessObjects.DTOs.Response;

public class LecturerResponseDto
{
    public int? LecturerId { get; set; }
    public int? RoleId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}