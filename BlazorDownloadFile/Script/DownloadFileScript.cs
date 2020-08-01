namespace BlazorDownloadFile
{
    internal class DownloadFileScript
    {
        /// <summary>
        /// Initializes BlazorDownloadFile on JavaScript
        /// </summary>
        /// <returns></returns>
        public static string InitializeBlazorDownloadFile()
        {
            return $@"
if(typeof _blazorDownloadFileBuffers === 'undefined')
{{
    var _blazorDownloadFileBuffers = new Array();
}}
else
{{
    _blazorDownloadFileBuffers = new Array();
}}
function _blazorDownloadFileBuffersPush(bytes)
{{
     _blazorDownloadFileBuffers.push(bytes);
}}
function _blazorDownloadFileClearBuffer()
{{
    _blazorDownloadFileBuffers = new Array();
}}
function _blazorDownloadFileAnyBuffer()
{{
    return _blazorDownloadFileBuffers && _blazorDownloadFileBuffers.length;
}}
function _blazorDownloadFileBuffersCount()
{{
    return _blazorDownloadFileBuffers ? _blazorDownloadFileBuffers.length : 0;
}}
function _blazorDowloadFileBase64String(fileName, bytesBase64, contentType)
{{
    if (navigator.msSaveBlob) 
    {{
        //Download document in Edge browser
        var _blazorDownloadFileData = atob(bytesBase64);
        var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
        for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
            _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
        }}
        _blazorDownloadFileData = null;
        var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: contentType }});
        _blazorDownloadFileBytes = null;
        navigator.msSaveBlob(_blazorDownloadFileBlob, fileName);
        _blazorDownloadFileBlob = null;
    }}
    else 
    {{
        //Download document in other browser
        var _blazorDownloadFileData = atob(bytesBase64);
        var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
        for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
            _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
        }}
        _blazorDownloadFileData = null;
        var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: contentType }});
        _blazorDownloadFileBytes = null;
        var _blazorDownloadFileLink = document.createElement(""a"");
        _blazorDownloadFileLink.download = fileName;
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
    }}
}}
function _blazorDowloadFileBase64StringPartitioned(fileName, contentType)
{{
    if (navigator.msSaveBlob) 
    {{
        //Download document in Edge browser
        var _blazorDownloadFileData = atob(_blazorDownloadFileBuffers.join(""""));
        _blazorDownloadFileBuffers = new Array();
        var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
        for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
            _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
        }}
        _blazorDownloadFileData = null;
        var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: contentType }});
        _blazorDownloadFileBytes = null;
        navigator.msSaveBlob(_blazorDownloadFileBlob, fileName);
        _blazorDownloadFileBlob = null;
    }}
    else 
    {{
        //Download document in other browser
        var _blazorDownloadFileData = atob(_blazorDownloadFileBuffers.join(""""));
        _blazorDownloadFileBuffers = new Array();
        var _blazorDownloadFileBytes = new Uint8Array(_blazorDownloadFileData.length);
        for (var i = 0; i < _blazorDownloadFileData.length; i++) {{
            _blazorDownloadFileBytes[i] = _blazorDownloadFileData.charCodeAt(i);
        }}
        _blazorDownloadFileData = null;
        var _blazorDownloadFileBlob = new Blob([_blazorDownloadFileBytes.buffer], {{ type: contentType }});
        _blazorDownloadFileBytes = null;
        var _blazorDownloadFileLink = document.createElement(""a"");
        _blazorDownloadFileLink.download = fileName;
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
    }}
}}
function _blazorDowloadFileByteArrayPartitioned(fileName, contentType)
{{
    if (navigator.msSaveBlob) 
    {{
        //Download document in Edge browser
        var _blazorDownloadFileBufferParts = new Array();
        for(var index = 0; index < _blazorDownloadFileBuffers.length; index++) {{
            var _blazorDownloadFileData = _blazorDownloadFileBuffers[index];
            _blazorDownloadFileBufferParts.push(new Uint8Array(_blazorDownloadFileBuffers[index]));
            _blazorDownloadFileBuffers[index] = null;
        }}
         _blazorDownloadFileBuffers = new Array();
        var _blazorDownloadFileBlob = new Blob(_blazorDownloadFileBufferParts, {{ type: contentType }});
        _blazorDownloadFileBufferParts = null;
        navigator.msSaveBlob(_blazorDownloadFileBlob, fileName);
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
         _blazorDownloadFileBuffers = new Array();
        var _blazorDownloadFileBlob = new Blob(_blazorDownloadFileBufferParts, {{ type: contentType }});
        _blazorDownloadFileBufferParts = null;
        var _blazorDownloadFileLink = document.createElement(""a"");
        _blazorDownloadFileLink.download = fileName;
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
    }}
}}";
        }
    }
}
