using System.Net;
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
            FirstName = registerRequestDto.FirstName,
            LastName = registerRequestDto.LastName,
            Phone = registerRequestDto.Phone,
            Address = registerRequestDto.Address
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
        var mail = new MailMessage
        {
            From = new MailAddress("swppass6@gmail.com"), 
            Subject = "Reset Your Password",
            Body = $"Your OTP code is: {otp}",
            IsBodyHtml = true
        };
        mail.To.Add(email);
        using (var client = new SmtpClient("smtp.gmail.com", 587)) 
        {
            client.EnableSsl = true; 
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("swppass6@gmail.com", "jason.tran.1234"); 
            try
            {
                client.Send(mail);
            }
            catch (SmtpException ex)
            {
                throw new Exception("Error sending email: " + ex.Message);
            }
        }
    }


}