using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDownloadFile
{
    /// <summary>
    /// This service helps download files from blazor context.
    /// </summary>
    public interface IBlazorDownloadFileService
    {
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
        /// <param name="cancellationTokenJavaScriptInterop">The cancellation token when executing javascript</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
        /// <param name="timeOutJavaScriptInterop">The timeout when executing javascript</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, CancellationToken cancellationToken, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, TimeSpan timeOut, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
        /// <param name="timeOutJavaScriptInterop">The cancellation token when executing javascript</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        ///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
        /// <param name="timeOutJavaScriptInterop">The timeout when executing javascript</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream");
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, int bufferSize = 32768, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "text/plain");
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        ValueTask DownloadFileFromText(string fileName, string plainText, TimeSpan timeOut, int bufferSize = 32768, string contentType = "text/plain");
    }
}