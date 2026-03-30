using Quartz;

namespace FulDownloader.Jobs;

public class VideoCleanupJob(ILogger<VideoCleanupJob> logger) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var files = Directory.GetFiles(Globals.DownloadPath);
        foreach (var filePath in files)
        {
            if (File.GetCreationTimeUtc(filePath) < DateTime.UtcNow.AddHours(-1))
            {
                File.Delete(filePath);
            }
        }
        logger.LogInformation($"Video cleanup job finished: removed {files.Length} files.");
    }
}