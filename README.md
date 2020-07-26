# BlazorDownloadFile

<p>
    	<a href="https://www.nuget.org/packages/BlazorDownloadFile">
	    <img src="https://buildstats.info/nuget/BlazorDownloadFile?v=1.0.12" />
	</a>
	<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RSE2NMEG3F7QU&source=url">
	    <img src="https://img.shields.io/badge/Donate-PayPal-green.svg" />
	</a>
</p>

![](BlazorDownloadFileDemo.gif)

Blazor download files to the browser from c# without any JavaScript library or dependency.

## Installation

`Install-Package BlazorDownloadFile -Version 1.0.12`

## Register the service in your services method

`services.AddBlazorDownloadFile();`

## No javascript library reference dependency

Since version 1.0.6. 

Please updgrade to latest version if you are using older versions.

## Usage

`[Inject] IBlazorDownloadFileService BlazorDownloadFileService { get; set; }`

### BlazorDownloadFileService Methods

```
ValueTask DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, string contentType = "application/octet-stream");
ValueTask DownloadFileFromText(string fileName, string plainText, string contentType = "text/plain");
ValueTask DownloadFileFromText(string fileName, string plainText, CancellationToken cancellationToken, string contentType = "text/plain");
ValueTask DownloadFileFromText(string fileName, string plainText, TimeSpan timeOut, string contentType = "text/plain");
ValueTask DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream");
ValueTask DownloadFileFromText(string fileName, string plainText, int bufferSize = 32768, string contentType = "text/plain");
ValueTask DownloadFileFromText(string fileName, string plainText, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "text/plain");
ValueTask DownloadFileFromText(string fileName, string plainText, TimeSpan timeOut, int bufferSize = 32768, string contentType = "text/plain");
```


## License
MIT
