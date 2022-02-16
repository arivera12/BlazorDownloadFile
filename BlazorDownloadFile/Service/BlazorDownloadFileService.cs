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
            Task.Run(async () => await JSRuntime.InvokeVoidAsync("eval", BlazorDownloadFileScript.InitializeBlazorDownloadFile()));
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(string bytesBase64)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytesBase64);
        }
        /// <inheritdoc/>>
        public ValueTask AddBuffer(string bytesBase64, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytesBase64);
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(string bytesBase64, TimeSpan timeOut)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytesBase64);
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(byte[] bytes)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytes.Select(s => s));
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(byte[] bytes, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytes.Select(s => s));
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(byte[] bytes, TimeSpan timeOut)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytes.Select(s => s));
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(IEnumerable<byte> bytes)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytes);
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(IEnumerable<byte> bytes, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytes);
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(IEnumerable<byte> bytes, TimeSpan timeOut)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytes);
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(Stream stream)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", stream.ToByteArrayAsync());
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(Stream stream, CancellationToken cancellationToken)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, stream.ToByteArrayAsync(cancellationToken));
        }
        /// <inheritdoc/>
        public ValueTask AddBuffer(Stream stream, CancellationToken streamReadcancellationToken, TimeSpan timeOutJavaScript)
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOutJavaScript, stream.ToByteArrayAsync(streamReadcancellationToken));
        }
        /// <inheritdoc/>
        public ValueTask<bool> AnyBuffer()
        {
            return JSRuntime.InvokeAsync<bool>("_blazorDownloadFileAnyBuffer");
        }
        /// <inheritdoc/>
        public ValueTask<int> BuffersCount()
        {
            return JSRuntime.InvokeAsync<int>("_blazorDownloadFileBuffersCount");
        }
        /// <inheritdoc/>
        public ValueTask ClearBuffers()
        {
            return JSRuntime.InvokeVoidAsync("_blazorDownloadFileClearBuffer");
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64StringPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64StringPartitioned", cancellationToken, fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64StringPartitioned", timeOut, fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream")
        {
//            if (JSRuntime is IJSUnmarshalledRuntime webAssemblyJSRuntime)
//{
//                webAssemblyJSRuntime.InvokeUnmarshalled<string, string, byte[], bool>("BlazorDownloadFileFast", fileName, contentType, file);
//            }
//            else
//            {
//                // Fall back to the slow method if not in WebAssembly
//                await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", fileName, contentType, file);
//            }
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", fileName, bytesBase64, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", cancellationToken, fileName, bytesBase64, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", timeOut, fileName, bytesBase64, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", fileName, Convert.ToBase64String(bytes), contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", cancellationToken, fileName, Convert.ToBase64String(bytes), contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", timeOut, fileName, Convert.ToBase64String(bytes), contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", bytes);
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, bytes);
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, string contentType = "application/octet-stream")
        {
            await ClearBuffers();
            await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, bytes);
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream")
        {
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", fileName, Convert.ToBase64String(await stream.ToByteArrayAsync()), contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, string contentType = "application/octet-stream")
        {
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", cancellationTokenJavaScriptInterop, fileName, Convert.ToBase64String(await stream.ToByteArrayAsync(cancellationTokenBytesRead)), contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, string contentType = "application/octet-stream")
        {
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64String", timeOutJavaScriptInterop, fileName, Convert.ToBase64String(await stream.ToByteArrayAsync(cancellationTokenBytesRead)), contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false)
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(encoding, encoderShouldEmitIdentifier), contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, CancellationToken cancellationToken, string contentType = "text/plain", bool encoderShouldEmitUTF8Identifier = false)
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(encoding, encoderShouldEmitUTF8Identifier), cancellationToken, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, TimeSpan timeOut, string contentType = "text/plain", bool encoderShouldEmitUTF8Identifier = false)
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(encoding, encoderShouldEmitUTF8Identifier), timeOut, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytesBase64.Length;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", string.Join("", partFile));
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64StringPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytesBase64.Length;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, string.Join("", partFile));
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64StringPartitioned", cancellationToken, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytesBase64.Length;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, string.Join("", partFile));
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileBase64StringPartitioned", timeOut, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytes.Length;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", partFile);
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytes.Length;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, partFile);
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytes.Length;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, partFile);
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            var bytesLength = bytes.Count();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytesLength;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", partFile);
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            var bytesLength = bytes.Count();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytesLength;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationToken, partFile);
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationToken, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
        {
            await ClearBuffers();
            var bytesReaded = 0;
            var bytesLength = bytes.Count();
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                bytesReaded += partFile.Count;
                var totalProgress = (double)bytesReaded / bytesLength;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOut, partFile);
            }
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOut, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
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
                var totalProgress = (double)totalOfBytesReaded / totalOfBytes;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", buffer.Select(b => b));
            } while (pendingBytesToRead > 0);
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
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
                var totalProgress = (double)totalOfBytesReaded / totalOfBytes;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", cancellationTokenJavaScriptInterop, buffer.Select(b => b));
            } while (pendingBytesToRead > 0);
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", cancellationTokenJavaScriptInterop, fileName, contentType);
        }
        /// <inheritdoc/>
        public async ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null)
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
                var totalProgress = (double)totalOfBytesReaded / totalOfBytes;
                progress?.Report(totalProgress);
                await JSRuntime.InvokeVoidAsync("_blazorDownloadFileBuffersPush", timeOutJavaScriptInterop, buffer.Select(b => b));
            } while (pendingBytesToRead > 0);
            return await JSRuntime.InvokeAsync<DownloadFileResult>("_blazorDowloadFileByteArrayPartitioned", timeOutJavaScriptInterop, fileName, contentType);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitUTF8Identifier = false)
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(encoding, encoderShouldEmitUTF8Identifier), bufferSize, contentType, progress);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitUTF8Identifier = false)
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(encoding, encoderShouldEmitUTF8Identifier), cancellationToken, bufferSize, contentType, progress);
        }
        /// <inheritdoc/>
        public ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, TimeSpan timeOut, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitUTF8Identifier = false)
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(encoding, encoderShouldEmitUTF8Identifier), timeOut, bufferSize, contentType, progress);
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
