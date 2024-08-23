﻿namespace EduManage.BusinessObjects.DTOs.Request;

public class RegisterRequestDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public string? Role { get; set; } 
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}