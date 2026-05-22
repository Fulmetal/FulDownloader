using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FulDownloader.Controllers;

[Route("api/download")]
public class DownloadController : Controller
{
    // GET
    [HttpGet("file")]
    public IActionResult DownloadFile([FromQuery] string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            return BadRequest("Filename is required");

        var sanitizedFilename = Path.GetFileName(filename);

        if (string.IsNullOrEmpty(sanitizedFilename))
            return BadRequest("Invalid filename");

        // Whitelist allowed characters in filenames (alphanumeric, dot, underscore, hyphen, space)
        if (!Regex.IsMatch(sanitizedFilename, @"^[a-zA-Z0-9._ -]+$"))
            return BadRequest("Filename contains invalid characters");

        // Construct the file path and resolve to absolute path
        var filePath = Path.Combine(Globals.DownloadPath, sanitizedFilename);
        var safePath = Path.GetFullPath(filePath);
        var downloadDirFullPath = Path.GetFullPath(Globals.DownloadPath);

        // Final defense: ensure resolved path stays within download directory
        if (!safePath.StartsWith(downloadDirFullPath, StringComparison.Ordinal))
            return BadRequest("Invalid file path");

        if (!System.IO.File.Exists(safePath))
            return NotFound("File not found");

        // Validate file exists and is accessible before streaming
        using var stream = System.IO.File.OpenRead(safePath);
        var contentType = "application/octet-stream";

        // Return with the safe (canonical) path — ensures the file actually served is the one we validated
        return PhysicalFile(safePath, contentType, sanitizedFilename, enableRangeProcessing: false);
    }
}
