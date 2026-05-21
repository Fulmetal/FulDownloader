using FulDownloader;
using FulDownloader.Components;
using MudBlazor.Services;
using FFMpegCore;
using FulDownloader.Jobs;
using FulDownloader.Services;
using Quartz;
using FulDownloader.Extensions;
using FulDownloader.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilogLogging(builder.Configuration, builder.Host);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAntiforgery();
builder.Services.AddDataProtection();

builder.Services.AddControllers();

builder.Services.AddMudServices();
builder.Services.AddScoped<IDownloadService, DownloadService>();
builder.Services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

builder.Services.AddQuartz(q =>
{
    q.UseSimpleTypeLoader();
    q.UseInMemoryStore();
    q.UseDefaultThreadPool(tp => tp.MaxConcurrency = 3);
    
    var vcJobKey = new JobKey("VideoCleanupJob");
    q.AddJob<VideoCleanupJob>(opts => opts.WithIdentity(vcJobKey));
    q.AddTrigger(opts => opts
        .ForJob(vcJobKey)
        .WithIdentity("VideoCleanupTrigger")
        .WithCronSchedule("0 0 */3 ? * *")); //every 3 hours
    
    var ytdlpUpdateJobKey = new JobKey("YtDlpUpdateJob");
    q.AddJob<YtDlpUpdateJob>(opts => opts.WithIdentity(ytdlpUpdateJobKey));
    q.AddTrigger(opts => opts
        .ForJob(ytdlpUpdateJobKey)
        .WithIdentity("YtDlpUpdateTrigger")
        .WithCronSchedule("0 0 */12 ? * *")); //every 12 hours
});

builder.Services.AddQuartzHostedService(o =>
    o.WaitForJobsToComplete = true);

var app = builder.Build();

if (!Directory.Exists(Globals.DownloadPath))
    Directory.CreateDirectory(Globals.DownloadPath);
GlobalFFOptions.Configure(options => options.BinaryFolder = Globals.BinFolder);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
// app.UseHttpsRedirection(); // Disabled for Docker - enable if behind HTTPS proxy

app.MapControllers();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
