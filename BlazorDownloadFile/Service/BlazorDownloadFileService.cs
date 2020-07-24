using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptBase64String(fileName, bytesBase64, contentType));
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptBase64String(fileName, Convert.ToBase64String(bytes), contentType));
        }
        /// <summary>
        ///  Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream")
        {
            return JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptBase64String(fileName, Convert.ToBase64String(stream.ToByteArray()), contentType));
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), contentType);
        }
        /// <summary>
        /// Download a file from blazor context to the browser 
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytesBase64">The bytes base 64 of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.InitializeBlazorDownloadFileBuffer()); 
            foreach (var partFile in Partition(bytesBase64, bufferSize))
            {
                await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.AddFileBufferBase64StringPartition(string.Join("", partFile)));
            }
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptBase64StringPartitioned(fileName, contentType));
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.InitializeBlazorDownloadFileBuffer());
            foreach (var partFile in Partition(bytes, bufferSize))
            {
                //await JSRuntime.InvokeVoidAsync("_blazorDownloadFileuint8arrayBufferPush", partFile.ToArray());
                await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.AddFileBufferDoubledBase64StringPartition(Convert.ToBase64String(partFile.ToArray())));
            }
            //await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptByteArrayPartitioned(fileName, contentType));
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptBase64StringPartitioned(fileName, contentType));
        }
        /// <summary>
        ///  Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async ValueTask DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.InitializeBlazorDownloadFileBuffer());
            var buffer = new byte[bufferSize];
            var pendingBytesToRead = 0;
            do
            {
                pendingBytesToRead = stream.Read(buffer, 0, bufferSize);
                foreach (var partFile in Partition(buffer, bufferSize))
                {
                    //await JSRuntime.InvokeVoidAsync("_blazorDownloadFileuint8arrayBufferPush", partFile.ToArray());
                    await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.AddFileBufferDoubledBase64StringPartition(Convert.ToBase64String(partFile.ToArray())));
                }
            } while (pendingBytesToRead > 0);
            stream.Flush();
            stream.Close();
            stream.Dispose();
            GC.Collect(1, GCCollectionMode.Forced);
            //await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptByteArrayPartitioned(fileName, contentType));
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScriptBase64StringPartitioned(fileName, contentType));
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public ValueTask DownloadFileFromText(string fileName, string plainText, int bufferSize = 32768, string contentType = "text/plain")
        {
            return DownloadFile(fileName, plainText.ToBase64Encode(), bufferSize, contentType);
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