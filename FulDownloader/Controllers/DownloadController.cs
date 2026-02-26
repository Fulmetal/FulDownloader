using Microsoft.AspNetCore.Mvc;

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

        var filePath = Path.Combine(Globals.DownloadPath, filename);

        if (!System.IO.File.Exists(filePath))
            return NotFound("File not found");

        var contentType = "application/octet-stream";

        return PhysicalFile(filePath, contentType, filename, enableRangeProcessing: true);
    }
}