namespace EduManage.Services.Helpers;

public class VerifyPassword
{
    public static bool Verify(string password, string hash)
    {
        return HashPassword.Hash(password) == hash;
    }
}