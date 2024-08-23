using System.Net.Mail;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.BusinessObjects.Entities;
using EduManage.Services.Helpers;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation;

public class AuthService(GenerateJWT generateJwt, ApplicationDbContext context) : IAuthService
{
    public LoginResponseDto Login(LoginRequestDto loginRequestDto)
    {
        var user = context.Lecturers.FirstOrDefault(x => x.Email == loginRequestDto.Email && x.Password == loginRequestDto.Password);
        if (user == null)
        {
            throw new Exception("Invalid credentials");
        }
        var token = generateJwt.GenerateToken(user.Email, user.LecturerId , user.UserName);
        return new LoginResponseDto
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(1)
        };
        
    }

    public void Register(RegisterRequestDto registerRequestDto)
    {
        if (context.Lecturers.Any(u => u.Email == registerRequestDto.Email))
        {
            throw new ArgumentException("Email already exists.");
        }

        var newUser = new Lecturer
        {
            Email = registerRequestDto.Email,
            Password = registerRequestDto.Password,
            UserName = registerRequestDto.Username,
        };
        context.Lecturers.Add(newUser);
        context.SaveChanges();
    }

    public void ForgotPassword(string email)
    {
        bool emailExist = context.Lecturers.Any(u => u.Email == email);
        if (!emailExist)
        {
            throw new ArgumentException("Email does not exist.");
        }
        string otp = GenerateOTP.Generate(6);
        SendEmail(email, otp);
    }
    
    private void SendEmail(string email, string otp)
    {
        MailMessage mail = new MailMessage("noreply@yourapp.com", email);
        mail.Subject = "Reset Your Password";
        mail.Body = $"Your OTP code is: {otp}";
        using (SmtpClient client = new SmtpClient("luan.tran2907@gmail.com"))
        {
            client.Send(mail);
        }
    }
}