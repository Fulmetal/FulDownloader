function downloadLargeFile(fileName) {
    // Trigger download via server endpoint
    const link = document.createElement('a');
    link.href = `/api/download/file?filename=${encodeURIComponent(fileName)}`;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function consoleWriteLine(line)
{
    console.log(line);
}