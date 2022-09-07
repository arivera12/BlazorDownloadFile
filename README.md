
# BlazorDownloadFile

<p>
	<a href="https://www.nuget.org/packages/BlazorDownloadFile">
	    <img src="https://buildstats.info/nuget/BlazorDownloadFile?v=2.4.0.2" />
	</a>
	<!--<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RSE2NMEG3F7QU&source=url">
	    <img src="https://img.shields.io/badge/Donate-PayPal-green.svg" />
	</a>-->
</p>

![](BlazorDownloadFileDemo.gif)

Blazor download files to the browser from c# without any JavaScript library or dependency.

BlazorDownloadFile is the solution to saving files on the client-side, and is perfect for web apps that generates files on the client. 

However if the file is coming from the server we recommend you to first try to use Content-Disposition attachment response header as it has more cross-browser compatibility.

## Installation

`Install-Package BlazorDownloadFile -Version 2.4.0.2`

## Register the service in your services method

`services.AddBlazorDownloadFile(ServiceLifetime lifetime = ServiceLifetime.Scoped);`

Note: `ServiceLifetime.Singleton` is not supported.

## No javascript library reference dependency unless...

## If you are using Content-Security-Policy "script-src 'self'" then you need to add the script manually: 

### <script src="_content/BlazorDownloadFile/BlazorDownloadFileScript.js"><script>

## Usage

`[Inject] IBlazorDownloadFileService BlazorDownloadFileService { get; set; }`

### BlazorDownloadFileService Methods

**AddBuffer**
```
// Adds a buffer to the javascript side
ValueTask AddBuffer(string bytesBase64);
```
| Parameter | Type |Description |
|--|--|--|
| `bytesBase64` | `string` | The base 64 string |

---
**AddBuffer**
```
// Adds a buffer to the javascript side
ValueTask AddBuffer(string bytesBase64, CancellationToken cancellationToken);
```
| Parameter | Type |Description |
|--|--|--|
| `bytesBase64` | `string` | The base 64 string |
| `cancellationToken` | `CancellationToken` | The cancellation token |
---
**AddBuffer**
```
// Adds a buffer to the javascript side
ValueTask AddBuffer(string bytesBase64, TimeSpan timeOut)
```
| Parameter | Type | Description |
|--|--|--|
| `bytesBase64` | `string` | The base 64 string |
| `timeOut` | `TimeSpan` | The timeout |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(byte[] bytes);
```
| Parameter | Type | Description |
|--|--|--|
| `bytes` | `byte[]` | The bytes |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(byte[] bytes, CancellationToken cancellationToken);
```
| Parameter | Type | Description |
|--|--|--|
| `bytes` | `byte[]` | The bytes |
| `cancellationToken` | `CancellationToken` | The cancellation token |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(byte[] bytes, TimeSpan timeOut);
```
| Parameter | Type | Description |
|--|--|--|
| `bytes` | `byte[]` | The bytes |
| `timeOut` | `TimeSpan` | The timeout |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(IEnumerable<byte> bytes);
```
| Parameter | Type | Description |
|--|--|--|
| `bytes` | `IEnumerable<byte>` | The bytes |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(IEnumerable<byte> bytes, CancellationToken cancellationToken);
```
| Parameter | Type | Description |
|--|--|--|
| `bytes` | `IEnumerable<byte>` | The bytes |
| `cancellationToken` | `CancellationToken` | The cancellation token |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(IEnumerable<byte> bytes, TimeSpan timeOut);
```
| Parameter | Type | Description |
|--|--|--|
| `bytes` | `IEnumerable<byte>` | The bytes |
| `timeOut` | `TimeSpan` | The timeout |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(Stream stream);
```
| Parameter | Type | Description |
|--|--|--|
| `stream` | `Stream` | The stream |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(Stream stream, CancellationToken cancellationToken);
```
| Parameter | Type | Description |
|--|--|--|
| `stream` | `Stream` | The stream |
| `cancellationToken` | `CancellationToken` | The cancellation token |
---
**AddBuffer**
```
// Adds a buffer to javascript side
ValueTask AddBuffer(Stream stream, CancellationToken streamReadcancellationToken, TimeSpan timeOutJavaScript);
```
| Parameter | Type | Description |
|--|--|--|
| `stream` | `Stream` | The stream |
| `streamReadcancellationToken` | `CancellationToken` | The cancellation token |
| `timeOutJavaScript` | `TimeSpan` | The timeout |
---
**AnyBuffer**
```
// Checks wether there is any buffer loaded in the JavaScript side.
ValueTask<bool> AnyBuffer();
```
---
**BuffersCount**
```
// Gets the buffers count loaded in the JavaScript side.
ValueTask<int> BuffersCount();
```
---
**ClearBuffers**
```
// Clears the buffers in javascript side
ValueTask ClearBuffers();
```
---
**DownloadBase64Buffers**
```
// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string type. 
ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `contentType` | `string` | The content type |
---
**DownloadBase64Buffers**
```
// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string type.
ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `contentType` | `string` | The content type |
---
**DownloadBase64Buffers**
```
// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string type.
ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `timeOut` | `TimeSpan` | The timeout |
| `contentType` | `string` | The content type |
---
**DownloadBinaryBuffers**
```
// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream types. 
ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `contentType` | `string` | The content type |
---
**DownloadBinaryBuffers**
```
// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream types. 
ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `contentType` | `string` | The content type |
---
**DownloadBinaryBuffers**
```
// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream types. 
ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `timeOut` | `TimeSpan` | The timeout |
| `contentType` | `string` | The content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytesBase64` | `string` | The bytes base 64 of the file |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytesBase64` | `string` | The bytes base 64 of the file |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytesBase64` | `string` | The bytes base 64 of the file |
| `timeOut` | `TimeSpan` | The timeout |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `byte[]` | The bytes of the file |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `byte[]` | The bytes of the file |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `byte[]` | The bytes of the file |
| `timeOut` | `TimeSpan` | The timeout |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `IEnumerable<byte>` | The bytes of the file |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `IEnumerable<byte>` | The bytes of the file |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `IEnumerable<byte>` | The bytes of the file |
| `timeOut` | `TimeSpan` | The timeout |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `stream` | `Stream` | The stream of the file |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `stream` | `Stream` | The stream of the file |
| `cancellationTokenBytesRead` | `CancellationToken` | The cancellation token when reading bytes |
| `cancellationTokenJavaScriptInterop` | `CancellationToken` | The cancellation token when executing javascript |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, string contentType = "application/octet-stream");
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `stream` | `Stream` | The stream of the file |
| `cancellationTokenBytesRead` | `CancellationToken` | The cancellation token when reading bytes |
| `timeOutJavaScriptInterop` | `TimeSpan` | The timeout when executing javascript |
| `contentType` | `string` | The file content type |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `plainText` | `string` | The stream of the file |
| `encoding` | `Encoding` | The encoding to use |
| `contentType` | `string` | The file content type |
| `encoderShouldEmitIdentifier` | `bool` | true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, CancellationToken cancellationToken, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `plainText` | `string` | The stream of the file |
| `encoding` | `Encoding` | The encoding to use |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `contentType` | `string` | The file content type |
| `encoderShouldEmitIdentifier` | `bool` | true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, TimeSpan timeOut, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `plainText` | `string` | The stream of the file |
| `encoding` | `Encoding` | The encoding to use |
| `timeOut` | `TimeSpan` | The timeout |
| `contentType` | `string` | The file content type |
| `encoderShouldEmitIdentifier` | `bool` | true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytesBase64` | `string` | The bytes base 64 of the file |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytesBase64` | `string` | The bytes base 64 of the file |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytesBase64` | `string` | The bytes base 64 of the file |
| `timeOut` | `TimeSpan` | The timeout |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `byte[]` | The bytes of the file |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `byte[]` | The bytes of the file |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `byte[]` | The bytes of the file |
| `timeOut` | `TimeSpan` | The timeout |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `IEnumerable<byte>` | The bytes of the file |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `IEnumerable<byte>` | The bytes of the file |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `bytes` | `IEnumerable<byte>` | The bytes of the file |
| `timeOut` | `TimeSpan` | The timeout |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `stream` | `Stream` | The bytes of the file |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `stream` | `Stream` | The bytes of the file |
| `cancellationTokenBytesRead` | `CancellationToken` | The cancellation token when reading bytes |
| `cancellationTokenJavaScriptInterop` | `CancellationToken` | The cancellation token when executing javascript |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFile**
```
// Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `stream` | `Stream` | The bytes of the file |
| `cancellationTokenBytesRead` | `CancellationToken` | The cancellation token when reading bytes |
| `timeOutJavaScriptInterop` | `TimeSpan` | The timeout when executing javascript |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
---
**DownloadFileFromText**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitIdentifier = false);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `plainText` | `string` | The plain text |
| `encoding` | `Encoding` | The encoding to use |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
| `encoderShouldEmitIdentifier` | `bool` | true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark |
---
**DownloadFileFromText**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitIdentifier = false);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `plainText` | `string` | The plain text |
| `encoding` | `Encoding` | The encoding to use |
| `cancellationToken` | `CancellationToken` | The cancellation token |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
| `encoderShouldEmitIdentifier` | `bool` | true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark |
---
**DownloadFileFromText**
```
// Download a file from blazor context to the browser
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, TimeSpan timeOut, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitIdentifier = false);
```
| Parameter | Type | Description |
|--|--|--|
| `fileName` | `string` | The filename |
| `plainText` | `string` | The plain text |
| `encoding` | `Encoding` | The encoding to use |
| `timeOut` | `TimeSpan` | The timeout |
| `bufferSize` | `int` | The buffer size |
| `contentType` | `string` | The file content type |
| `progress` | `IProgress<double>?` | The progress percent of data transferred |
| `encoderShouldEmitIdentifier` | `bool` | true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark |
---
### Performance Considerations and Understandings

Regarding on some performance test I have done in this library is that, `base64` string and `byte[]` performs faster than `Stream` always. 

Since there is not direct conversion between from c# `Stream` to a JavaScript object its a little more expensive this task. 

When its `base64` this is the most simple data type to transfer and work with it. 

`byte[]` gets transformed into `base64` string when transfered to JavaScript and for some reason it won't work properly when encoding cause its `base64` representation turns to be something else when going after the second partition when gets encoded to `base64` string. (If anyone knows how to fix or workaround this make a pull request) 

Based on the las sentence, a list of bytes gets passed down from c#  to JavaScript as an array of intergers with the bytes representation on JavaScript and this is the reason why I send a `IList<byte>` rather than `byte[]` internally to JavaScript. 

The binary representation seems to perform very well since we just needed to call `Uint8Array` and push the binary representation entirely into the array to then pass it down to the JavaScript native `Blob` object. 

<b>Take note that you may use the overload methods with buffers if you are sending big files over the wire and also that browsers have their own limitations on [JavaScript Max Blob Size](https://stackoverflow.com/questions/28307789/is-there-any-limitation-on-javascript-max-blob-size) based on the device hardware, browser vendor and the OS.</b>

<b>Take note also that blazor server side uses [Signal R](https://docs.microsoft.com/en-us/aspnet/core/signalr/security?view=aspnetcore-3.1#buffer-management) and has its data transfer (buffer) limitations.</b>

## License
MIT
