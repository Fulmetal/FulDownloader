using System.Net;
using Quartz;

namespace FulDownloader.Jobs;

public class VideoCleanupJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        var files = Directory.GetFiles(Globals.DownloadPath);
        foreach (var filePath in files)
        {
            if (File.GetCreationTimeUtc(filePath) < DateTime.UtcNow.AddHours(-1))
            {
                File.Delete(filePath);
            }
        }
        return Task.CompletedTask;
    }
}