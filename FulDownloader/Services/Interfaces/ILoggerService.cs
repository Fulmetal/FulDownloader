namespace FulDownloader.Services.Interfaces;

public interface ILoggerService<T>
{
    void LogFatal(string message, Exception ex);
    void LogError(string message, Exception ex);
    void LogWarning(string message);
    void LogWarning(string message, Exception? ex);
    void LogSuccess(string message);
    void LogInfo(string message);
    void LogInfo(string message, Exception? ex);
}