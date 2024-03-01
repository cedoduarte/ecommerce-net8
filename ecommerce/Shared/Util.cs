using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace ecommerce.Shared
{
    public static class Util
    {
        public const string EmailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}$";
        public const string UrlPattern = @"^(http|https)://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(/\S*)?$";
        public const string UsernamePattern = @"^[a-zA-Z0-9_-]{3,16}$";

        public static bool IsValidEmail(string input)
        {
            return Regex.IsMatch(input, EmailPattern);
        }

        public static bool IsValidUrl(string input)
        {
            return Regex.IsMatch(input, UrlPattern);
        }

        public static bool IsValidUsername(string input)
        {
            return Regex.IsMatch(input, UsernamePattern);
        }

        public static bool IsValidPassword(string input)
        {
            return PasswordValidator.IsValid(input);
        }

        public static string GetSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var hash = new StringBuilder();
                byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                foreach (byte b in hashArray)
                {
                    hash.Append(b.ToString("x"));
                }
                return hash.ToString();
            }
        }
    }
}
