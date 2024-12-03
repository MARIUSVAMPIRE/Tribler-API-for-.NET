using System;
using System.Linq;

namespace Tribler.API.Test.WinFrom;

public static class StringExtension
{
    public static bool Contains(this string fullString, string value, StringComparison comparison)
    {
        return fullString.IndexOf(value, comparison) > -1;
    }
    public static string RemoveWhiteSpaces(this string str)
    {
        return string.Concat(str.Where(c => !Char.IsWhiteSpace(c)));
    }
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input[0].ToString().ToUpper() + input.Substring(1).ToLower()
        };
}
