using Quartz;
using Quartz.Impl;
using FulDownloader.Exceptions;
using FulDownloader.Jobs;

namespace FulDownloader;

public static class Scheduler
{
    public const string SchedulerName = "myScheduler";
    
    public static async Task Init()
    {
        await StartScheduler();
        await ScheduleVideoCleanupJob();
        await ScheduleYtdlpUpdateJob();
    }

    public static async Task StartScheduler()
    {
        var scheduler = await GetScheduler();
        if (!scheduler.IsStarted)
            await scheduler.Start();
    }

    public static async Task StopScheduler()
    {
        var scheduler = await GetScheduler();
        if (scheduler.IsStarted)
            await scheduler.Shutdown();
    }

    public static async Task<IScheduler> GetScheduler()
    {
        var schedulerFactory = new StdSchedulerFactory();
        var scheduler = await schedulerFactory.GetScheduler();
        return scheduler ?? throw new DownloaderException("Scheduler not found.", "Scheduler");
    }

    public static async Task ScheduleVideoCleanupJob()
    {
        var scheduler = await GetScheduler();
        
        IJobDetail job = JobBuilder.Create<VideoCleanupJob>()
            .WithIdentity("VideoCleanupJob", "downloaderGroup")
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("VideoCleanupTrigger", "downloaderGroup")
            .WithCronSchedule("0 0 */3 ? * *") //every 3 hours
            .Build();
        
        await scheduler.ScheduleJob(job, trigger);
    }

    public static async Task ScheduleYtdlpUpdateJob()
    {
        var scheduler = await GetScheduler();
        IJobDetail job = JobBuilder.Create<YtDlpUpdateJob>()
            .WithIdentity("YtDlpUpdateJob", "updateGroup")
            .Build();
        
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("YtDlpUpdateTrigger", "updateGroup")
            .WithCronSchedule("0 0 */12 ? * *") //every 12 hours
            .Build();
    }
}