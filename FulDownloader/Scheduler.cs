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
        
        //TODO: change chron schedule to every few hours
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("VideoCleanupTrigger", "downloaderGroup")
            .WithCronSchedule("0 0 */2 ? * *") //every 2 hours
            .Build();
        
        await scheduler.ScheduleJob(job, trigger);
    }
}