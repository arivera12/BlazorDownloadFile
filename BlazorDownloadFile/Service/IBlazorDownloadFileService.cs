using System.IO;
using System.Threading.Tasks;

namespace BlazorDownloadFile
{
    /// <summary>
    /// This service helps download files from blazor context.
    /// </summary>
    public interface IBlazorDownloadFileService
    {
        /// <summary>
        /// Download a file from blazor context to the browser. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the browser. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The bytes base 64 of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, int bufferSize = 32768, string contentType = "text/plain");
    }
}