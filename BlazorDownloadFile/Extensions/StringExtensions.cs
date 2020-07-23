using System;
using System.Text;

namespace BlazorDownloadFile
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts a string to base 64 string
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string ToBase64Encode(this string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }
    }
}
