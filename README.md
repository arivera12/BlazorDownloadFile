# BlazorDownloadFile
Blazor download files to the browser from c#. 

This packages was inspired of blazor lacks of built-in binary data downloader. 

This packages makes that posible with a little js interop.

## Installation

`Install-Package BlazorDownloadFile -Version 1.0.2`

## Add reference in _Imports.razor

`@using BlazorDownloadFile`

## Add the service in your services method

`services.AddBlazorDownloadFile();`

## Add javascript library reference in your index.html

`<script src="_content/BlazorDownloadFile/blazorDownloadFile.js"></script>`

## Usage

`[Inject] BlazorDownloadFileService BlazorDownloadFileService { get; set; }`

#### Dowload File Methods

`BlazorDownloadFileService.DownloadFile(string fileName, string bytesBase64)`

`BlazorDownloadFileService.DownloadFile(string fileName, byte[] bytes)`

`BlazorDownloadFileService.DownloadFile(string fileName, Stream stream)`

## License
MIT
