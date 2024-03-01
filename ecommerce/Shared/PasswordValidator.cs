using System.Text.RegularExpressions;

namespace ecommerce.Shared
{
    public static class PasswordValidator
    {
        public const int MinimumLength = 8;

        public static bool IsValid(string input)
        {
            return HasMinimumLength(input)
                   && HasUpperCaseLetter(input)
                   && HasLowerCaseLetter(input)
                   && HasDigit(input)
                   && HasSpecialCharacter(input);
        }

        private static bool HasMinimumLength(string input)
        {
            return input.Length >= MinimumLength;
        }

        private static bool HasUpperCaseLetter(string input)
        {
            string pattern = @"[A-Z]";
            return Regex.IsMatch(input, pattern);
        }

        private static bool HasLowerCaseLetter(string input)
        {
            string pattern = @"[a-z]";
            return Regex.IsMatch(input, pattern);
        }

        private static bool HasDigit(string input)
        {
            string pattern = @"\d";
            return Regex.IsMatch(input, pattern);
        }

        private static bool HasSpecialCharacter(string input)
        {
            string pattern = @"[^a-zA-Z\d]";
            return Regex.IsMatch(input, pattern);
        }
    }
}
