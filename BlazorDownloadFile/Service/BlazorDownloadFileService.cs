using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, bytesBase64, contentType));
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async Task DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(bytes), contentType));
        }
        /// <summary>
        ///  Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async Task DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(stream.ToByteArray()), contentType));
        }
        /// <summary>
        /// Download a file from blazor context to the brower
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="plainText">The plain text</param>
        /// <param name="contentType">The file content type</param>
        /// <returns></returns>
        public async Task DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain")
        {
            await DownloadFile(fileName, plainText.ToBase64Encode(), contentType);
        }







        ///// <summary>
        ///// Download a file from blazor context to the browser 
        ///// </summary>
        ///// <param name="fileName">The filename</param>
        ///// <param name="bytesBase64">The bytes base 64 of the file</param>
        ///// <param name="contentType">The file content type</param>
        ///// <param name="BufferSize">The buffer size</param>
        ///// <returns></returns>
        //public async Task DownloadFile(string fileName, string bytesBase64, int bufferSize = 4000000, string contentType = "application/octet-stream")
        //{
        //    var key = Guid.NewGuid().ToString();
        //    foreach (var partFile in Partition(bytesBase64, bufferSize))
        //    {
        //        await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.AddFileBuffer(partFile));
        //    }
        //    await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, bytesBase64, contentType));
        //}
        ///// <summary>
        ///// Download a file from blazor context to the browser
        ///// </summary>
        ///// <param name="fileName">The filename</param>
        ///// <param name="bytes">The bytes of the file</param>
        ///// <param name="contentType">The file content type</param>
        ///// <param name="BufferSize">The buffer size</param>
        ///// <returns></returns>

        //public async Task DownloadFile(string fileName, byte[] bytes, int bufferSize = 4000000, string contentType = "application/octet-stream")
        //{
        //    /// https://gist.github.com/JPVenson/8eb2686b2f07d28014d0f4098d0e04c4
        //    var key = Guid.NewGuid().ToString();
        //    foreach (var partFile in Partition(bytes, bufferSize))
        //    {
        //        await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.AddFileBuffer(partFile));
        //    }
        //    await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, contentType));
        //    //await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(bytes), contentType));
        //}
        ///// <summary>
        /////  Download a file from blazor context to the browser
        ///// </summary>
        ///// <param name="fileName">The filename</param>
        ///// <param name="stream">The stream of the file</param>
        ///// <param name="contentType">The file content type</param>
        ///// <param name="BufferSize">The buffer size</param>
        ///// <returns></returns>
        //public async Task DownloadFile(string fileName, Stream stream, int bufferSize = 4000000, string contentType = "application/octet-stream")
        //{
        //    await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(stream.ToByteArray(bufferSize)), contentType));
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="plainText"></param>
        ///// <param name="contentType">The file content type</param>
        ///// <param name="BufferSize">The buffer size</param>
        ///// <returns></returns>
        //public async Task DownloadFileFromText(string fileName, string plainText, int bufferSize = 4000000, string contentType = "text/plain")
        //{
        //    await DownloadFile(fileName, plainText.ToBase64Encode(), bufferSize, contentType);
        //}
        /// <summary>
        /// Parts any type by the buffer size.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="bufferSize"></param>
        /// <returns></returns>
        //internal IEnumerable<List<T>> Partition<T>(IEnumerable<T> source, int bufferSize)
        //{
        //    for (int i = 0; i < Math.Ceiling(source.Count() / (double)bufferSize); i++)
        //    {
        //        yield return new List<T>(source.Skip(bufferSize * i).Take(bufferSize));
        //    }
        //}
    }
}