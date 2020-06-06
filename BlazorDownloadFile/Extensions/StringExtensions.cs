using System;
using System.Text;

namespace BlazorDownloadFile
{
    internal static class StringExtensions
    {
        public static string ToBase64Encode(this string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }
    }
}
