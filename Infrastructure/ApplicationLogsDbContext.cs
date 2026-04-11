using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationLogsDbContext : DbContext
{
    public ApplicationLogsDbContext(DbContextOptions<ApplicationLogsDbContext> options) : base(options)
    {
    }

    public DbSet<LogDataModel> Logs { get; set; } = default!;
}

public class LogDataModel
{
    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Level { get; set; } = string.Empty;
    public string? Exception { get; set; } = string.Empty;
    public string? RenderedMessage { get; set; } = string.Empty;
    public string? Properties { get; set; } = string.Empty;
}
