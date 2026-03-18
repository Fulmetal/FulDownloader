using FulDownloader;
using FulDownloader.Components;
using MudBlazor.Services;
using FFMpegCore;
using FulDownloader.Services;
using Microsoft.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddControllers();

builder.Services.AddMudServices();
builder.Services.AddScoped<IDownloadService, DownloadService>();

await Scheduler.Init();

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
