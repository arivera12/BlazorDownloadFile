# BlazorDownloadFile
Blazor download files to the browser from c#.

## Installation

`Install-Package BlazorDownloadFile -Version 1.0.0`

## Add reference in _Imports.razor

`@using BlazorDownloadFile`

## Add the service in your services method

`services.AddBlazorDownloadFile();`

## Add javascript library reference in your index.html

`<script src="_content/BlazorDownloadFile/blazorDownloadFile.js"></script>`

## Usage

`[Inject] BlazorDownloadFile BlazorDownloadFile { get; set; }`

#### Dowload File Methods

`BlazorDownloadFile.DownloadFile(string fileName, string bytesBase64)`

`BlazorDownloadFile.DownloadFile(string fileName, byte[] bytes)`

`BlazorDownloadFile.DownloadFile(string fileName, Stream stream)`

## License
MIT
