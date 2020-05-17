using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorDownloadFile
{
    public class BlazorDownloadFileService : IBlazorDownloadFileService
    {
        /// <summary>
        /// The javascript runtime
        /// </summary>
        protected IJSRuntime JSRuntime { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public BlazorDownloadFileService()
        {
        }
        /// <summary>
        /// Constructor witht he javascript runtime
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
        public async ValueTask DownloadFile(string fileName, string bytesBase64)
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, bytesBase64));
        }
        /// <summary>
        /// Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="bytes">The bytes of the file</param>
        /// <returns></returns>
        public async ValueTask DownloadFile(string fileName, byte[] bytes)
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(bytes)));
        }
        /// <summary>
        ///  Download a file from blazor context to the browser
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <param name="stream">The stream of the file</param>
        /// <returns></returns>
        public async ValueTask DownloadFile(string fileName, Stream stream)
        {
            await JSRuntime.InvokeVoidAsync("eval", DownloadFileScript.DownloadFileJavascriptScript(fileName, Convert.ToBase64String(stream.ToByteArray())));
        }
    }
}