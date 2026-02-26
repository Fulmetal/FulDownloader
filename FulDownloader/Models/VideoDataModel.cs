namespace FulDownloader.Models;

public class VideoDataModel
{
    public string VideoName { get; set; } = string.Empty;
    public string VideoFilename => $"{VideoName}.mp4";
    public string VideoFilePath => $"{Globals.DownloadPath}/{VideoFilename}";
    public List<VideoFormatModel>? VideoFormats { get; set; }
    public string VideoThumbnail { get; set; } = string.Empty;
    public float? VideoDuration { get; set; }
}