namespace FulDownloader.Services;

using Microsoft.JSInterop;
using Interfaces;

public class DownloadService : IDownloadService
{
    private readonly IJSRuntime _jsRuntime;

    public DownloadService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task DownloadMp4Async(string fileName, string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {fileName} not found");
        }
        
        await _jsRuntime.InvokeVoidAsync("downloadLargeFile", fileName);
    }
}