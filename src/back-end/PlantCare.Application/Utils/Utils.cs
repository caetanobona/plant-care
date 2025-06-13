using System.Security.Cryptography;
using System.Text;

namespace PlantCare.Application.Utils;

public static class Utils
{
    public static string GetSha256Hash(string input)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash);
    }
}