namespace FulDownloader.Extensions;

public static class StringExtensions
{
    private static readonly char[] InvalidFileNameChars = ['<', '>', ':', '"', '/', '\\', '|', '?', '*', '\0'];
    
    public static string ToSafeFilename(this string inputString)
    {
        inputString = new string(inputString.Where(x => !InvalidFileNameChars.Contains(x)).ToArray());

        if (inputString.Length == 0)
            inputString = "_";
        
        return inputString;
    }
}