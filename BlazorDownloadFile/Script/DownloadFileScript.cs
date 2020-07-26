namespace BlazorDownloadFile
{
    internal class DownloadFileScript
    {
        /// <summary>
        /// The download script of the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bytesBase64"></param>
        /// <returns></returns>
        public static string DownloadFileJavascriptScriptBase64String(string fileName, string bytesBase64, string contentType)
        {
            return $@"
if (navigator.msSaveBlob) 
{{
    //Download document in Edge browser
    var _blazorDownloadFileData = atob(""{bytesBase64}"");
    var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
    for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
        _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
    }}
    _blazorDownloadFileData = null;
    var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: ""{contentType}"" }});
    _blazorDownloadFileBytes = null;
    navigator.msSaveBlob(_blazorDownloadFileBlob, ""{fileName}"");
    _blazorDownloadFileBlob = null;
}}
else 
{{
    //Download document in other browser
    var _blazorDownloadFileData = atob(""{bytesBase64}"");
    var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
    for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
        _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
    }}
    _blazorDownloadFileData = null;
    var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: ""{contentType}"" }});
    _blazorDownloadFileBytes = null;
    var _blazorDownloadFileLink = document.createElement(""a"");
    _blazorDownloadFileLink.download = ""{fileName}"";
    _blazorDownloadFileLink.style.display = ""none"";
    var _blazorDownloadFileObjectUrl = URL.createObjectURL(_blazorDownloadFileBlob); 
    _blazorDownloadFileLink.href = _blazorDownloadFileObjectUrl;
    document.body.appendChild(_blazorDownloadFileLink); // Needed for Firefox
    _blazorDownloadFileLink.click();
    URL.revokeObjectURL(_blazorDownloadFileObjectUrl);
    _blazorDownloadFileObjectUrl = null;
    _blazorDownloadFileBlob = null;
    document.body.removeChild(_blazorDownloadFileLink);
    _blazorDownloadFileLink = null;
}}";
        }
        /// <summary>
        /// The download script of the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bytesBase64"></param>
        /// <returns></returns>
        public static string DownloadFileJavascriptScriptBase64StringPartitioned(string fileName, string contentType)
        {
            return $@"
if (navigator.msSaveBlob) 
{{
    //Download document in Edge browser
    var _blazorDownloadFileData = atob(_blazorDownloadFileBuffers.join(""""));
    _blazorDownloadFileBuffers = null;
    var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
    for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
        _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
    }}
    _blazorDownloadFileData = null;
    var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: ""{contentType}"" }});
    _blazorDownloadFileBytes = null;
    navigator.msSaveBlob(_blazorDownloadFileBlob, ""{fileName}"");
    _blazorDownloadFileBlob = null;
}}
else 
{{
    //Download document in other browser
    var _blazorDownloadFileData = atob(_blazorDownloadFileBuffers.join(""""));
    _blazorDownloadFileBuffers = null;
    var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
    for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
        _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
    }}
    _blazorDownloadFileData = null;
    var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: ""{contentType}"" }});
    _blazorDownloadFileBytes = null;
    var _blazorDownloadFileLink = document.createElement(""a"");
    _blazorDownloadFileLink.download = ""{fileName}"";
    _blazorDownloadFileLink.style.display = ""none"";
    var _blazorDownloadFileObjectUrl = URL.createObjectURL(_blazorDownloadFileBlob); 
    _blazorDownloadFileLink.href = _blazorDownloadFileObjectUrl;
    document.body.appendChild(_blazorDownloadFileLink); // Needed for Firefox
    _blazorDownloadFileLink.click();
    URL.revokeObjectURL(_blazorDownloadFileObjectUrl);
    _blazorDownloadFileObjectUrl = null;
    _blazorDownloadFileBlob = null;
    document.body.removeChild(_blazorDownloadFileLink);
    _blazorDownloadFileLink = null;
}}";
        }
        /// <summary>
        /// The download script of the file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bytesBase64"></param>
        /// <returns></returns>
        public static string DownloadFileJavascriptScriptByteArrayPartitioned(string fileName, string contentType)
        {
            return $@"
if (navigator.msSaveBlob) 
{{
    //Download document in Edge browser
    var _blazorDownloadFileBufferParts = new Array();
    for(var index = 0; index < _blazorDownloadFileBuffers.length; index++) {{
        var _blazorDownloadFileData = _blazorDownloadFileBuffers[index];
        _blazorDownloadFileBufferParts.push(new Uint8Array(_blazorDownloadFileBuffers[index]));
        _blazorDownloadFileBuffers[index] = null;
    }}
     _blazorDownloadFileBuffers = null;
    var _blazorDownloadFileBlob = new Blob(_blazorDownloadFileBufferParts, {{ type: ""{contentType}"" }});
    _blazorDownloadFileBufferParts = null;
    navigator.msSaveBlob(_blazorDownloadFileBlob, ""{fileName}"");
    _blazorDownloadFileBlob = null;
}}
else 
{{
    //Download document in other browser
    var _blazorDownloadFileBufferParts = new Array();
    for(var index = 0; index < _blazorDownloadFileBuffers.length; index++) {{
        var _blazorDownloadFileData = _blazorDownloadFileBuffers[index];
        _blazorDownloadFileBufferParts.push(new Uint8Array(_blazorDownloadFileBuffers[index]));
        _blazorDownloadFileBuffers[index] = null;
    }}
     _blazorDownloadFileBuffers = null;
    var _blazorDownloadFileBlob = new Blob(_blazorDownloadFileBufferParts, {{ type: ""{contentType}"" }});
    _blazorDownloadFileBufferParts = null;
    var _blazorDownloadFileLink = document.createElement(""a"");
    _blazorDownloadFileLink.download = ""{fileName}"";
    _blazorDownloadFileLink.style.display = ""none"";
    var _blazorDownloadFileObjectUrl = URL.createObjectURL(_blazorDownloadFileBlob); 
    _blazorDownloadFileLink.href = _blazorDownloadFileObjectUrl;
    document.body.appendChild(_blazorDownloadFileLink); // Needed for Firefox
    _blazorDownloadFileLink.click();
    URL.revokeObjectURL(_blazorDownloadFileObjectUrl);
    _blazorDownloadFileObjectUrl = null;
    _blazorDownloadFileBlob = null;
    document.body.removeChild(_blazorDownloadFileLink);
    _blazorDownloadFileLink = null;
}}";
        }
        /// <summary>
        /// Initializes BlazorDownloadFileBuffer on JavaScript
        /// </summary>
        /// <returns></returns>
        public static string InitializeBlazorDownloadFileBuffer()
        {
            return $@"
if(typeof _blazorDownloadFileBuffers === 'undefined')
{{
    var _blazorDownloadFileBuffers = new Array();
}}
if(_blazorDownloadFileBuffers === null)
{{
    _blazorDownloadFileBuffers = new Array();
}}
function _blazorDownloadFileBuffersPush(bytes)
{{
     _blazorDownloadFileBuffers.push(bytes);
}}";
        }
        /// <summary>
        /// Adds file to javascript native buffer
        /// </summary>
        /// <param name="bytesBase64"></param>
        /// <returns></returns>
        public static string AddFileBufferBase64StringPartition(string bytesBase64)
        {
            return $@"
_blazorDownloadFileBuffers.push(""{bytesBase64}"");";
        }
    }
}
