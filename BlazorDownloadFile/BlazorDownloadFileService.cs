using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorDownloadFile
{
    public class BlazorDownloadFileService
    {
        protected IJSRuntime JSRuntime { get; set; }
        public BlazorDownloadFileService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }
        public async ValueTask DownloadFile(string fileName, string bytesBase64)
        {
            await JSRuntime.InvokeVoidAsync("downloadFile", fileName, bytesBase64);
        }
        public async ValueTask DownloadFile(string fileName, byte[] bytes)
        {
            await JSRuntime.InvokeVoidAsync("downloadFile", fileName, Convert.ToBase64String(bytes));
        }
        public async ValueTask DownloadFile(string fileName, Stream stream)
        {
            await JSRuntime.InvokeVoidAsync("downloadFile", fileName, Convert.ToBase64String(stream.ToByteArray()));
        }
    }
    internal static class StreamExtensions
    {
        internal static byte[] ToByteArray(this Stream stream)
        {
            var streamLength = (int)stream.Length;
            var data = new byte[streamLength + 1];
            stream.Read(data, 0, streamLength);
            stream.Close();
            stream.Dispose();
            return data;
        }
    }
}
