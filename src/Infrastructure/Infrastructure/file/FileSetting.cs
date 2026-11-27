namespace Infrastructure.file;

public static class FileSetting
{
    public static readonly IReadOnlyCollection<string> ValidExtensions =
        new List<string> { ".jpg", ".png", ".jpeg", };
    
    public const long MaxFileSize = 1024 * 1024 * 5;

    public static readonly string BaseUrl = "https://localhost:7269/uploads/";
}