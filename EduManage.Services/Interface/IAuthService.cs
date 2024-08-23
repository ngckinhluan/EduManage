using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;

namespace EduManage.Services.Interface;

public interface IAuthService
{
    LoginResponseDto Login(LoginRequestDto loginRequestDto);
    void Register(RegisterRequestDto registerRequestDto);
    void ForgotPassword(string email);
}