namespace TrainsOnline.Common.Extensions
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        public static string RemoveWhitespaces(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
