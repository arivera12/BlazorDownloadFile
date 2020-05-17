using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorDownloadFile
{
    public interface IBlazorDownloadFileService
    {
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64);
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes);
        /// <summary>
        ///  Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream);
    }
}