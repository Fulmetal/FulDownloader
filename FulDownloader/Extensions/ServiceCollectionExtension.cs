using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace FulDownloader.Extensions;

public static class ServiceCollectionExtension
{
   public static IServiceCollection AddSerilogLogging(this IServiceCollection services, ConfigureHostBuilder host)
   {
      var logDbPath = "/tmp/fuldownloader/logs.db";
      services.AddLogging();
      host.UseSerilog((ctx, lc) => lc
         .MinimumLevel.Information()
         .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
         .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)         .
         WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
         .WriteTo.SQLite(
            tableName: "Logs",
            sqliteDbPath: logDbPath,
            restrictedToMinimumLevel: LogEventLevel.Information,
            batchSize: ctx.HostingEnvironment.IsDevelopment() ? (uint)1 : (uint)50,
            retentionPeriod: new TimeSpan(7, 0, 0) 
         )
         .MinimumLevel.ControlledBy(new LoggingLevelSwitch() {  MinimumLevel  = LogEventLevel.Information, })
      );
      
     services.AddDbContext<ApplicationLogsDbContext>(o => o.UseSqlite($"Data Source={logDbPath}"));
     return services;
   }
}
