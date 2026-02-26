namespace FulDownloader.Models;

public class VideoFormatModel
{
    public string Resolution { get; set; } = string.Empty;
    public float? FrameRate { get; set; }
    public string FormatNote { get; set; } = string.Empty;
    public string Uri { get; set; } = string.Empty;
    public string FormatCode { get; set; } = string.Empty;
}