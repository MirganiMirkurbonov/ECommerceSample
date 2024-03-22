using System.Security.Cryptography;
using System.Text;

namespace Domain.Helpers;

public class CryptoHelper
{
    public static string ComputeSha256Hash(string input)
    {
        var sourceBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(sourceBytes);
        return Convert.ToHexString(hashBytes);
    }
}