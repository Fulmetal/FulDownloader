using Quartz;
using YoutubeDLSharp;

namespace FulDownloader.Jobs;

public class YtDlpUpdateJob(ILogger<YtDlpUpdateJob> logger) : IJob
{
    private YoutubeDL? Ytdl { get; set; }
    
    public async ValueTask Execute(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        Ytdl = new YoutubeDL
        {
            YoutubeDLPath = Globals.YtDlpPath
        };
        var str = await Ytdl.RunUpdate();
        
        logger.LogInformation($"YtDlp update job finished: {str}");
    }
}