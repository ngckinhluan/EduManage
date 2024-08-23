namespace EduManage.Services.Helpers;

public class GenerateOTP
{
    public static string Generate(int length)
    {
        const string chars = "0123456789";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}