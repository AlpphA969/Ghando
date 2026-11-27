using Ghando.Service.Contracts;
using Microsoft.AspNetCore.Http;


namespace Ghando.Service.FileService.Contracts;

public interface IFileService
{
    Task<Result<string>> UploadFile(IFormFile? file);
}