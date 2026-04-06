using Quartz;

namespace FulDownloader.Jobs;

public class VideoCleanupJob(ILogger<VideoCleanupJob> logger) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var deletedFiles = 0;
        var files = Directory.GetFiles(Globals.DownloadPath);
        foreach (var filePath in files)
        {
            if (File.GetCreationTimeUtc(filePath) < DateTime.UtcNow.AddHours(-1))
            {
                File.Delete(filePath);
                deletedFiles++;
            }
        }
        logger.LogInformation($"Video cleanup job finished: found {files.Length} files, removed {deletedFiles} files.");
    }
}