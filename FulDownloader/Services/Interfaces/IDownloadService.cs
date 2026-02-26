namespace FulDownloader.Services;

public interface IDownloadService
{
    Task DownloadMp4Async(string fileName, string filePath);
}