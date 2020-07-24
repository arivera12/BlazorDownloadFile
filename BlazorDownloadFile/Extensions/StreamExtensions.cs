using System;
using System.IO;

namespace BlazorDownloadFile
{
    internal static class StreamExtensions
    {
        /// <summary>
        /// Converts a stream into a byte array
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns></returns>
        internal static byte[] ToByteArray(this Stream stream)
        {
            var bytes = (stream as MemoryStream).ToArray();
            stream.Flush();
            stream.Close();
            stream.Dispose();
            GC.Collect(1, GCCollectionMode.Forced);
            return bytes;
        }
    }
}
