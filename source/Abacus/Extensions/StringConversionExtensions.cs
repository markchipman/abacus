namespace System
{
    public static class StringConversionExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string @string)
        {
            return string.IsNullOrEmpty(@string?.Trim());
        }
    }
}
