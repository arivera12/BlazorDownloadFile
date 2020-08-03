using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDownloadFile
{
    internal class BlazorDownloadFileService : IBlazorDownloadFileService
    {
        /// <summary>
        /// The javascript runtime
        /// </summary>
        protected IJSRuntime JSRuntime { get; set; }
        /// <summary>
        /// Constructor with the javascript runtime from IOC
        /// </summary>
        /// <param name="jSRuntime">The javascript runtime</param>
        public BlazorDownloadFileService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
            Task.Run(async() => await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.InitializeBlazorDownloadFile()));
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytesBase64">The base 64 string</param>
        /// <returns></returns>
        public ValueTask AddBuffer(string bytesBase64)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytesBase64);
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytesBase64">The base 64 string</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public ValueTask AddBuffer(string bytesBase64, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytesBase64);
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytesBase64">The base 64 string</param>
        /// <param name="timeOut">The timeout</param>
        /// <returns></returns>
        public ValueTask AddBuffer(string bytesBase64, TimeSpan timeOut)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytesBase64);
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <returns></returns>
        public ValueTask AddBuffer(byte[] bytes)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytes.Select(s => s));
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public ValueTask AddBuffer(byte[] bytes, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytes.Select(s => s));
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <param name="timeOut">The timeout</param>
        /// <returns></returns>
        public ValueTask AddBuffer(byte[] bytes, TimeSpan timeOut)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytes.Select(s => s));
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <returns></returns>
        public ValueTask AddBuffer(IEnumerable<byte> bytes)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytes);
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public ValueTask AddBuffer(IEnumerable<byte> bytes, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytes);
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <param name="timeOut">The timeout</param>
        /// <returns></returns>
        public ValueTask AddBuffer(IEnumerable<byte> bytes, TimeSpan timeOut)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytes);
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns></returns>
        public ValueTask AddBuffer(Stream stream)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", stream.ToByteArrayAsync());
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public ValueTask AddBuffer(Stream stream, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, stream.ToByteArrayAsync(cancellationToken));
        }
        /// <summary>
        /// Adds a buffer to javascript side
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="streamReadcancellationToken">The cancellation token</param>
        /// <param name="timeOutJavaScript">The timeout</param>
        /// <returns></returns>
        public ValueTask AddBuffer(Stream stream, CancellationToken streamReadcancellationToken, TimeSpan timeOutJavaScript)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOutJavaScript, stream.ToByteArrayAsync(streamReadcancellationToken));
        }
        /// <summary>
        /// Checks wether there is any buffer loaded in the JavaScript side.
        /// </summary>
        /// <returns></returns>
        public ValueTask<bool> AnyBuffer()
        {
            return JSRuntime.InvokeAsync<bool>("_blazorDownloadFileAnyBuffer");
        }
        /// <summary>
        /// Gets the buffers count loaded in the JavaScript side.
        /// </summary>
        /// <returns></returns>
        public ValueTask<int> BuffersCount()
        {
            return JSRuntime.InvokeAsync<int>("_blazorDownloadFileBuffersCount");
        }
        /// <summary>
        /// Clears all variables in javascript side
        /// </summary>
        /// <returns></returns>
        public ValueTask ClearBuffers()
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileClearBuffer");
        }
        /// <summary>
        /// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="contentType">The content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadBase64Buffers(string fileName, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64StringPartitioned", fileName, contentType);
        }
        /// <summary>
        /// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <param name="contentType">The content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadBase64Buffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64StringPartitioned", cancellationToken, fileName, contentType);
        }
        /// <summary>
        /// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="timeOut">The timeout</param>
        /// <param name="contentType">The content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadBase64Buffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64StringPartitioned", timeOut, fileName, contentType);
        }
        /// <summary>
        /// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="contentType">The content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadBinaryBuffers(string fileName, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <summary>
        /// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <param name="contentType">The content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadBinaryBuffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <summary>
        /// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream. 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="timeOut">The timeout</param>
        /// <param name="contentType">The content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadBinaryBuffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", fileName, bytesBase64, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", cancellationToken, fileName, bytesBase64, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", timeOut, fileName, bytesBase64, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", fileName, Convert.ToBase64String(bytes), contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", cancellationToken, fileName, Convert.ToBase64String(bytes), contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", timeOut, fileName, Convert.ToBase64String(bytes), contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytes);
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytes);
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytes);
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream")
        {
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", fileName, Convert.ToBase64String(await stream.ToByteArrayAsync()), contentType);
        }
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
        /// <param name="cancellationTokenJavaScriptInterop">The cancellation token when executing javascript</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, string contentType = "application/octet-stream")
        {
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", cancellationTokenJavaScriptInterop, fileName, Convert.ToBase64String(await stream.ToByteArrayAsync(cancellationTokenBytesRead)), contentType);
        }
        /// <summary>
        ///  Download a file from blazor context to the browser.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
        /// <param name="timeOutJavaScriptInterop">The timeout when executing javascript</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, string contentType = "application/octet-stream")
        {
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64String", timeOutJavaScriptInterop, fileName, Convert.ToBase64String(await stream.ToByteArrayAsync(cancellationTokenBytesRead)), contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFileFromText(string fileName, string plainText, CancellationToken cancellationToken, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), cancellationToken, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFileFromText(string fileName, string plainText, TimeSpan timeOut, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), timeOut, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", string.Join("", partFile));
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64StringPartitioned", fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, string.Join("", partFile));
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64StringPartitioned", cancellationToken, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, string.Join("", partFile));
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileBase64StringPartitioned", timeOut, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", partFile);
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, partFile);
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, partFile);
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", partFile);
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, partFile);
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, partFile);
            }
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <summary>
        ///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            var totalOfBytes = (int)stream.Length;
            var totalOfBytesReaded = 0;
            var pendingBytesToRead = totalOfBytes;
            do
            {
                var currentBufferSize = bufferSize > totalOfBytes ? totalOfBytes : bufferSize > pendingBytesToRead ? pendingBytesToRead : bufferSize;
                var buffer = new byte[currentBufferSize];
                totalOfBytesReaded += await stream.ReadAsync(buffer, 0, currentBufferSize);
                pendingBytesToRead -= totalOfBytesReaded;
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", buffer.Select(b => b));
            } while (pendingBytesToRead > 0);
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
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
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            var totalOfBytes = (int)stream.Length;
            var totalOfBytesReaded = 0;
            var pendingBytesToRead = totalOfBytes;
            do
            {
                var currentBufferSize = bufferSize > totalOfBytes ? totalOfBytes : bufferSize > pendingBytesToRead ? pendingBytesToRead : bufferSize;
                var buffer = new byte[currentBufferSize];
                totalOfBytesReaded += await stream.ReadAsync(buffer, 0, currentBufferSize, cancellationTokenBytesRead);
                pendingBytesToRead -= totalOfBytesReaded;
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationTokenJavaScriptInterop, buffer.Select(b => b));
            } while (pendingBytesToRead > 0);
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationTokenJavaScriptInterop, fileName, contentType);
        }
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
        public async ValueTask<DowloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            var totalOfBytes = (int)stream.Length;
            var totalOfBytesReaded = 0;
            var pendingBytesToRead = totalOfBytes;
            do
            {
                var currentBufferSize = bufferSize > totalOfBytes ? totalOfBytes : bufferSize > pendingBytesToRead ? pendingBytesToRead : bufferSize;
                var buffer = new byte[currentBufferSize];
                totalOfBytesReaded += await stream.ReadAsync(buffer, 0, currentBufferSize, cancellationTokenBytesRead);
                pendingBytesToRead -= totalOfBytesReaded;
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOutJavaScriptInterop, buffer.Select(b => b));
            } while (pendingBytesToRead > 0);
            return await JSRuntime.InvokeAsync<DowloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOutJavaScriptInterop, fileName, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFileFromText(string fileName, string plainText, int bufferSize = 32768, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), bufferSize, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFileFromText(string fileName, string plainText, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), cancellationToken, bufferSize, contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="timeOut">The timeout of the operation</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask<DowloadFileResult> DownloadFileFromText(string fileName, string plainText, TimeSpan timeOut, int bufferSize = 32768, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), timeOut, bufferSize, contentType);
        }
        /// <summary>
        /// Parts any collection type by the buffer size.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The enumarable</param>
        /// <param name="bufferSize">The buffer size to partition the enumerable</param>
        /// <returns></returns>
        internal IEnumerable<IList<T>> Partition<T>(IEnumerable<T> source, int bufferSize)
        {
            for (int i = 0; i < Math.Ceiling(source.Count() / (double)bufferSize); i++)
            {
                yield return new List<T>(source.Skip(bufferSize * i).Take(bufferSize));
            }
        }
    }
}