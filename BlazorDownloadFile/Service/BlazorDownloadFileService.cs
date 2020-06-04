using Microsoft.JSInterop;
using System;
using System.IO;
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
        /// <returns></returns>
        public async Task DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream")
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(stream.ToByteArray()), contentType));
        }
    }
}