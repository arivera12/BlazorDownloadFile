# BlazorDownloadFile

<p>
	<a href="https://www.nuget.org/packages/BlazorDownloadFile">
	    <img src="https://buildstats.info/nuget/BlazorDownloadFile?v=2.3.1.1" />
	</a>
	<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RSE2NMEG3F7QU&source=url">
	    <img src="https://img.shields.io/badge/Donate-PayPal-green.svg" />
	</a>
</p>

![](BlazorDownloadFileDemo.gif)

Blazor download files to the browser from c# without any JavaScript library or dependency.

BlazorDownloadFile is the solution to saving files on the client-side, and is perfect for web apps that generates files on the client. 

However if the file is coming from the server we recommend you to first try to use Content-Disposition attachment response header as it has more cross-browser compatibility.

## Installation

`Install-Package BlazorDownloadFile -Version 2.3.1.1`

## Register the service in your services method

`services.AddBlazorDownloadFile(ServiceLifetime lifetime = ServiceLifetime.Scoped);`

Note: `ServiceLifetime.Singleton` is not supported.

## No javascript library reference dependency unless...

## If you are using Content-Security-Policy "script-src 'self'" then you need to add the script manually: 

### <script src="_content/BlazorDownloadFile/BlazorDownloadFileScript.js"><script>

## Usage

`[Inject] IBlazorDownloadFileService BlazorDownloadFileService { get; set; }`

### BlazorDownloadFileService Methods

```
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytesBase64">The base 64 string</param>
/// <returns></returns>
ValueTask AddBuffer(string bytesBase64);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytesBase64">The base 64 string</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <returns></returns>
ValueTask AddBuffer(string bytesBase64, CancellationToken cancellationToken);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytesBase64">The base 64 string</param>
/// <param name="timeOut">The timeout</param>
/// <returns></returns>
ValueTask AddBuffer(string bytesBase64, TimeSpan timeOut);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytes">The bytes</param>
/// <returns></returns>
ValueTask AddBuffer(byte[] bytes);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytes">The bytes</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <returns></returns>
ValueTask AddBuffer(byte[] bytes, CancellationToken cancellationToken);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytes">The bytes</param>
/// <param name="timeOut">The timeout</param>
/// <returns></returns>
ValueTask AddBuffer(byte[] bytes, TimeSpan timeOut);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytes">The bytes</param>
/// <returns></returns>
ValueTask AddBuffer(IEnumerable<byte> bytes);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytes">The bytes</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <returns></returns>
ValueTask AddBuffer(IEnumerable<byte> bytes, CancellationToken cancellationToken);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="bytes">The bytes</param>
/// <param name="timeOut">The timeout</param>
/// <returns></returns>
ValueTask AddBuffer(IEnumerable<byte> bytes, TimeSpan timeOut);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="stream">The stream</param>
/// <returns></returns>
ValueTask AddBuffer(Stream stream);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="stream">The stream</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <returns></returns>
ValueTask AddBuffer(Stream stream, CancellationToken cancellationToken);
/// <summary>
/// Adds a buffer to javascript side
/// </summary>
/// <param name="stream">The stream</param>
/// <param name="streamReadcancellationToken">The cancellation token</param>
/// <param name="timeOutJavaScript">The timeout</param>
/// <returns></returns>
ValueTask AddBuffer(Stream stream, CancellationToken streamReadcancellationToken, TimeSpan timeOutJavaScript);
/// <summary>
/// Checks wether there is any buffer loaded in the JavaScript side.
/// </summary>
/// <returns></returns>
ValueTask<bool> AnyBuffer();
/// <summary>
/// Gets the buffers count loaded in the JavaScript side.
/// </summary>
/// <returns></returns>
ValueTask<int> BuffersCount();
/// <summary>
/// Clears the buffers in javascript side
/// </summary>
/// <returns></returns>
ValueTask ClearBuffers();
/// <summary>
/// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string type. 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="contentType">The content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, string contentType = "application/octet-stream");
/// <summary>
/// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string type. 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="contentType">The content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream");
/// <summary>
/// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a base64 string type. 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="timeOut">The timeout</param>
/// <param name="contentType">The content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadBase64Buffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream");
/// <summary>
/// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream types. 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="contentType">The content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, string contentType = "application/octet-stream");
/// <summary>
/// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream types. 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="contentType">The content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, CancellationToken cancellationToken, string contentType = "application/octet-stream");
/// <summary>
/// Merges and downloads all pending buffers into a single file in the browser. This method should be called when the added buffers where a byte array, byte enumerable or a stream types. 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="timeOut">The timeout</param>
/// <param name="contentType">The content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadBinaryBuffers(string fileName, TimeSpan timeOut, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytesBase64">The bytes base 64 of the file</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytesBase64">The bytes base 64 of the file</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytesBase64">The bytes base 64 of the file</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, string contentType = "application/octet-stream");
/// <summary>
///  Download a file from blazor context to the browser.
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="stream">The stream of the file</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, string contentType = "application/octet-stream");
/// <summary>
///  Download a file from blazor context to the browser.
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="stream">The stream of the file</param>
/// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
/// <param name="cancellationTokenJavaScriptInterop">The cancellation token when executing javascript</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, string contentType = "application/octet-stream");
/// <summary>
///  Download a file from blazor context to the browser.
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="stream">The stream of the file</param>
/// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
/// <param name="timeOutJavaScriptInterop">The timeout when executing javascript</param>
/// <param name="contentType">The file content type</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, string contentType = "application/octet-stream");
/// <summary>
/// Download a file from blazor context to the brower
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="plainText">The plain text</param>
/// <param name="encoding">The enconding to use</param>
/// <param name="contentType">The file content type</param>
/// <param name="encoderShouldEmitIdentifier">true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark.</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false);
/// <summary>
/// Download a file from blazor context to the brower
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="plainText">The plain text</param>
/// <param name="encoding">The enconding to use</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="contentType">The file content type</param>
/// <param name="encoderShouldEmitIdentifier">true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark.</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, CancellationToken cancellationToken, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false);
/// <summary>
/// Download a file from blazor context to the brower
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="plainText">The plain text</param>
/// <param name="encoding">The enconding to use</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="contentType">The file content type</param>
/// <param name="encoderShouldEmitIdentifier">true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark.</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, TimeSpan timeOut, string contentType = "text/plain", bool encoderShouldEmitIdentifier = false);
/// <summary>
/// Download a file from blazor context to the browser 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytesBase64">The bytes base 64 of the file</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytesBase64">The bytes base 64 of the file</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser 
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytesBase64">The bytes base 64 of the file</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, string bytesBase64, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, byte[] bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the browser
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="bytes">The bytes of the file</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, IEnumerable<byte> bytes, TimeSpan timeOut, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="stream">The stream of the file</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="stream">The stream of the file</param>
/// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
/// <param name="cancellationTokenJavaScriptInterop">The cancellation token when executing javascript</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, CancellationToken cancellationTokenJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
///  Download a file from blazor context to the browser. Please take note that this method doesn't reset the stream position to 0.
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="stream">The stream of the file</param>
/// <param name="cancellationTokenBytesRead">The cancellation token when reading bytes</param>
/// <param name="timeOutJavaScriptInterop">The timeout when executing javascript</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFile(string fileName, Stream stream, CancellationToken cancellationTokenBytesRead, TimeSpan timeOutJavaScriptInterop, int bufferSize = 32768, string contentType = "application/octet-stream", IProgress<double>? progress = null);
/// <summary>
/// Download a file from blazor context to the brower
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="plainText">The plain text</param>
/// <param name="encoding">The enconding to use</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <param name="encoderShouldEmitIdentifier">true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark.</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitIdentifier = false);
/// <summary>
/// Download a file from blazor context to the brower
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="plainText">The plain text</param>
/// <param name="encoding">The enconding to use</param>
/// <param name="cancellationToken">The cancellation token</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <param name="encoderShouldEmitIdentifier">true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark.</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, CancellationToken cancellationToken, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitIdentifier = false);
/// <summary>
/// Download a file from blazor context to the brower
/// </summary>
/// <param name="fileName">The filename</param>
/// <param name="plainText">The plain text</param>
/// <param name="encoding">The enconding to use</param>
/// <param name="timeOut">The timeout of the operation</param>
/// <param name="bufferSize">The buffer size</param>
/// <param name="contentType">The file content type</param>
/// <param name="progress">The progress percent of data transfered</param>
/// <param name="encoderShouldEmitIdentifier">true to specify that the System.Text.Encoding.GetPreamble method returns a Unicode byte order mark.</param>
/// <returns></returns>
ValueTask<DownloadFileResult> DownloadFileFromText(string fileName, string plainText, Encoding encoding, TimeSpan timeOut, int bufferSize = 32768, string contentType = "text/plain", IProgress<double>? progress = null, bool encoderShouldEmitIdentifier = false);
```

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
