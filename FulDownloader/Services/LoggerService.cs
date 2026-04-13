namespace FulDownloader.Services;

using MudBlazor;
using Interfaces;

public class LoggerService<T> : ILoggerService<T>
{
    private readonly ILogger<T> _logger;
    private readonly ISnackbar _snackbar;

    public LoggerService(ILogger<T> logger, ISnackbar snackbar)
    {
        _logger = logger;
        _snackbar = snackbar;
    }
    
    public void LogFatal(string message, Exception ex)
    {
        HandleMessageString(ref message, ex);
        _logger.LogError(message, ex.Message);
        _snackbar.Add(message, Severity.Error);
    }

    public void LogError(string message, Exception ex)
    {
        HandleMessageString(ref message, ex);
        _logger.LogError(message, ex.Message);
        _snackbar.Add(message, Severity.Error);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
        _snackbar.Add(message, Severity.Warning);
    }
    
    public void LogWarning(string message, Exception? ex)
    {
        HandleMessageString(ref message, ex);
        _logger.LogWarning(message, ex);
        _snackbar.Add(message, Severity.Warning);
    }

    public void LogSuccess(string message)
    {
        _logger.LogInformation(message);
        _snackbar.Add(message, Severity.Success);
    }
    
    public void LogInfo(string message)
    {
        _logger.LogInformation(message);
        _snackbar.Add(message, Severity.Info);
    }
    
    public void LogInfo(string message, Exception? ex)
    {
        HandleMessageString(ref message, ex);
        _logger.LogInformation(message, ex);
        _snackbar.Add(message, Severity.Info);
    }

    private static void HandleMessageString(ref string message, Exception? ex)
    {
        if (string.IsNullOrEmpty(message))
        {
            if (ex != null)
            {
                message = ex.Message;
            }
        }
    }
}