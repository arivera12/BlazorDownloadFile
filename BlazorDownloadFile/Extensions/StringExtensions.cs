using System;
using System.Linq;
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
        public static string ToBase64Encode(this string plainText, bool encoderShouldEmitUTF8Identifier)
        {
            if(encoderShouldEmitUTF8Identifier)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(plainText)).ToArray());
            }
            else
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
            } 
        }
    }
}
