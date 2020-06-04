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
        public static string DownloadFileJavascriptScript(string fileName, string bytesBase64, string contentType)
        {
            return $@"
if (navigator.msSaveBlob) 
{{
    //Download document in Edge browser
    var data = window.atob(""{bytesBase64}"");
    var bytes = new Uint8Array(data.length);
    for (var i = 0; i < data.length; i++) {{
        bytes[i] = data.charCodeAt(i);
    }}
    var blob = new Blob([bytes.buffer], {{ type: ""{contentType}"" }});
    navigator.msSaveBlob(blob, ""{fileName}"");
}}
else 
{{
    var link = document.createElement('a');
    link.download = ""{fileName}"";
    link.style.display = ""none"";
    link.href = ""data:{contentType};base64,"" + ""{bytesBase64}"";
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}}";
        }
    }
}
