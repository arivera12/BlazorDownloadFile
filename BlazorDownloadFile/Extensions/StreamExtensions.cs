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
            stream.Close();
            stream.Dispose();
            GC.Collect(1, GCCollectionMode.Forced);
            return bytes;
        }
        ///// <summary>
        ///// Converts a stream into a byte array
        ///// </summary>
        ///// <param name="stream">The stream</param>
        ///// <param name="bufferSize">The buffer size</param>
        ///// <returns></returns>
        //internal static byte[] ToByteArray(this Stream stream, int bufferSize)
        //{
        //    var buffer = new byte[bufferSize];
        //    for (int index = 0; index < ((int)(stream as MemoryStream).Length / bufferSize); index++)
        //    {
        //        yield return (byte)(stream as MemoryStream).get(buffer, 0, (int)stream.Length);
        //    }
        //    foreach (var bytes in (stream as MemoryStream).ReadByte(buffer, 0, (int)stream.Length))
        //    {

        //    }
        //    stream.Close();
        //    stream.Dispose();
        //    GC.Collect(1, GCCollectionMode.Forced);
        //    return bytes;
        //}
    }
}
