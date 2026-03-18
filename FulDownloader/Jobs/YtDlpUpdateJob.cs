using Quartz;
using YoutubeDLSharp;

namespace FulDownloader.Jobs;

public class YtDlpUpdateJob : IJob
{
    private YoutubeDL? Ytdl { get; set; }
    
    public Task Execute(IJobExecutionContext context)
    {
        Ytdl = new YoutubeDL();
        Ytdl.YoutubeDLPath = Globals.YtDlpPath;
        Ytdl.RunUpdate();
        return Task.CompletedTask;
    }
}