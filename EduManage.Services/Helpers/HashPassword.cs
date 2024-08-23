namespace EduManage.Services.Helpers;

public class HashPassword
{
    public static string Hash(string password)
    {
        var data = System.Text.Encoding.ASCII.GetBytes(password);
        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        return System.Text.Encoding.ASCII.GetString(data);
    }
}