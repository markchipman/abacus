﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringNullExtensions
    {
        public static string SplitPascalCase(this string @string)
        {
            return Regex.Replace(Regex.Replace(@string, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }

        public static string ToCamelCase(this string @string)
        {
            if (!string.IsNullOrEmpty(@string) && @string.Length > 1)
            {
                return char.ToLowerInvariant(@string[0]) + @string.Substring(1);
            }

            return @string;
        }

        public static string ToTitleCase(this string @string)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(@string);
        }

        public static string ReplaceSpaceWith(this string @string, string delimiter)
        {
            return @string?.Replace(" ", delimiter);
        }
    }
}
