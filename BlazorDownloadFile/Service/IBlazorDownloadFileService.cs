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
        /// <param name="plainTextData">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        Task DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the browser. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        Task DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        Task DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        Task DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream");
    }
}