using System.IO;

namespace BlazorDownloadFile
{
    internal static class StreamExtensions
    {
        /// <summary>
        /// Converts a stream into a byte array
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal static byte[] ToByteArray(this Stream stream)
        {
            var streamLength = (int)stream.Length;
            var data = new byte[streamLength + 1];
            stream.Read(data, 0, streamLength);
            stream.Close();
            stream.Dispose();
            return data;
        }
    }
}
