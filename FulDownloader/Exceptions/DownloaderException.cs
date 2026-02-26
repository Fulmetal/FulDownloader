using System.Runtime.CompilerServices;

namespace FulDownloader.Exceptions;

public class DownloaderException : Exception
{
    public DownloaderException(string message, string service) : base(message)
    {
        Service = service;
    }
    
    private string Service { get; set; }
}
