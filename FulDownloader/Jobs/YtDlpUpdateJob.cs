using Quartz;
using YoutubeDLSharp;

namespace FulDownloader.Jobs;

public class YtDlpUpdateJob(ILogger<VideoCleanupJob> logger) : IJob
{
    private YoutubeDL? Ytdl { get; set; }
    
    public async Task Execute(IJobExecutionContext context)
    {
        Ytdl = new YoutubeDL
        {
            YoutubeDLPath = Globals.YtDlpPath
        };
        var str = await Ytdl.RunUpdate();
        
        logger.LogInformation($"YtDlp update job finished: {str}");
    }
}