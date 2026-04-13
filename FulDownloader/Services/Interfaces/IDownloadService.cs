namespace FulDownloader.Services.Interfaces;

public interface IDownloadService
{
    Task DownloadMp4Async(string fileName, string filePath);
}