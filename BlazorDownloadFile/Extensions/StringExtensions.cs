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
        public static string ToBase64Encode(this string plainText, bool encoderShouldEmitUTF8Identifier = true)
        {
            return Convert.ToBase64String(new UTF8Encoding(encoderShouldEmitUTF8Identifier).GetBytes(plainText));
        }
    }
}
