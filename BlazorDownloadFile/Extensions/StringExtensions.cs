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
        /// <param name="plainText">The plain text</param>
        /// <param name="encoding">Represents a character encoding</param>
        /// <param name="encoderShouldEmitIdentifier">A byte array containing a sequence of bytes that specifies the encoding used.</param>
        /// <returns></returns>
        public static string ToBase64Encode(this string plainText, Encoding encoding, bool encoderShouldEmitIdentifier)
        {
            if(encoderShouldEmitIdentifier)
            {
                return Convert.ToBase64String(encoding.GetPreamble().Concat(encoding.GetBytes(plainText)).ToArray());
            }
            else
            {
                return Convert.ToBase64String(encoding.GetBytes(plainText));
            } 
        }
    }
}
