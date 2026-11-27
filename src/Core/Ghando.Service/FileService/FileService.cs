using Ghando.Service.Contracts;
using Ghando.Service.FileService.Contracts;
using Microsoft.AspNetCore.Http;
using System.IO;
using Ghando.Service.FileService.Contracts.Exceptions;
using Infrastructure.file;

namespace Ghando.Service.FileService;

public class FileService : IFileService
{
    public async Task<Result<string>> UploadFile(IFormFile? file)
    {
        string fileExtension = Path.GetExtension(file.FileName);

        var isValidExtension =
            FileSetting.ValidExtensions.Contains(fileExtension);

        if (!isValidExtension)
        {
            return FileExceptions.InvalidFileFormat();
        }
        
        var fileLength = file.Length;

        if (fileLength > FileSetting.MaxFileSize)
        {
            return FileExceptions.FileSizeExceeded();
        }

        var filePath =
            Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/uploads");
        
        var fileName = Guid.NewGuid() + fileExtension;
        
        var fullPath = Path.Combine(filePath , fileName);

        await using FileStream fileStream = new FileStream(fullPath , FileMode.Create);
        
        await file.CopyToAsync(fileStream);
        
        return Path.Combine(FileSetting.BaseUrl,fileName);
        
        
        
        
        
        
        
        






        
    }
}