using System;
namespace Sports.Core.Helpers
{

    public static class StringExtensions
    {
        public static string FirstLetterUpperCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var month = $"{char.ToUpper(value[0])}{value.Substring(1)}";
            return month;
        }
    }
}
