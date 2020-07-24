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
    _blazorDownloadFileLink.href = URL.createObjectURL(_blazorDownloadFileBlob);
    document.body.appendChild(_blazorDownloadFileLink); // Needed for Firefox
    _blazorDownloadFileLink.click();
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
    var _blazorDownloadFileData = atob(_blazorDownloadFileBase64Buffers.join(""""));
    _blazorDownloadFileBase64Buffers = null;
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
    var _blazorDownloadFileBase64BufferParts = new Array();
    for(var _blazorDownloadFileBase64Buffer in _blazorDownloadFileBase64Buffers) {{
        var _blazorDownloadFileData = atob(_blazorDownloadFileBase64Buffer);
        var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
        for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
            _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
        }}
        _blazorDownloadFileBase64BufferParts.push(_blazorDownloadFileBytes);
        _blazorDownloadFileBytes = null;
        _blazorDownloadFileData = null;
    }}
     _blazorDownloadFileBase64Buffers = null;
    var _blazorDownloadFileBlob = new Blob(_blazorDownloadFileBase64BufferParts, {{ type: ""{contentType}"" }});
    _blazorDownloadFileBase64BufferParts = null;
    var _blazorDownloadFileLink = document.createElement(""a"");
    _blazorDownloadFileLink.download = ""{fileName}"";
    _blazorDownloadFileLink.style.display = ""none"";
    _blazorDownloadFileLink.href = URL.createObjectURL(_blazorDownloadFileBlob);
    document.body.appendChild(_blazorDownloadFileLink); // Needed for Firefox
    _blazorDownloadFileLink.click();
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
//        public static string DownloadFileJavascriptScriptByteArrayPartitioned(string fileName, string contentType)
//        {
//            return $@"
//if (navigator.msSaveBlob) 
//{{
//    //Download document in Edge browser
//    var bytes = new Uint8Array(_blazorDownloadFileByteArrayBuffer.length);
//    for (var i = 0; i < _blazorDownloadFileByteArrayBuffer.length; i++) {{
//        bytes[i] = _blazorDownloadFileByteArrayBuffer[i];
//    }}
//    var blob = new Blob([bytes.buffer], {{ type: ""{contentType}"" }});
//    _blazorDownloadFileByteArrayBuffer = null;
//    parts = null;
//    navigator.msSaveBlob(blob, ""{fileName}"");
//}}
//else 
//{{
//    //Download document in other browser
//    var parts = new Array();
//    for (var base64Part in _blazorDownloadFileByteArrayBuffer) {{
//        var bytes = new Uint8Array(_blazorDownloadFileByteArrayBuffer.length);
//        for (var i = 0; i < base64Part.length; i++) {{
//            bytes[i] = base64Part.charCodeAt(i);
//        }}
//        parts.push(bytes);
//    }}
//    var blob = new Blob(parts, {{ type: ""{contentType}"" }});
//    //_blazorDownloadFileByteArrayBuffer = null;
//    //parts = null;
//    var link = document.createElement(""a"");
//    link.download = ""{fileName}"";
//    link.style.display = ""none"";
//    link.href = URL.createObjectURL(blob);
//    document.body.appendChild(link); // Needed for Firefox
//    link.click();
//    document.body.removeChild(link);
//}}
//";
//        }
        /// <summary>
        /// Initializes BlazorDownloadFileBuffer on JavaScript
        /// </summary>
        /// <returns></returns>
        public static string InitializeBlazorDownloadFileBuffer()
        {
            return $@"
if(typeof _blazorDownloadFileBase64Buffers === 'undefined')
{{
    var _blazorDownloadFileBase64Buffers = new Array();
}}
if(_blazorDownloadFileBase64Buffers === null)
{{
    _blazorDownloadFileBase64Buffers = new Array();
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
_blazorDownloadFileBase64Buffers.push(""{bytesBase64}"");";
        }
        /// <summary>
        /// Adds file to javascript native buffer
        /// </summary>
        /// <param name="bytesBase64"></param>
        /// <returns></returns>
        public static string AddFileBufferDoubledBase64StringPartition(string bytesBase64)
        {
            return $@"
_blazorDownloadFileBase64Buffers.push(btoa(""{bytesBase64}""));";
        }
    }
}
