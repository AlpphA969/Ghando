using Ghando.Service.Contracts;

namespace Ghando.Service.FileService.Contracts.Exceptions;

public static class FileExceptions
{
    public static Error InvalidFileFormat() => new Error(
        "Invalid file format",
        ErrorType.InvalidInput,
        "فایل نامناسب");

    public static Error FileSizeExceeded() => new Error("File size exceeded",
        ErrorType.InvalidInput, "اندازه ی فایل بیشتر از حد مجاز");

    public static Error FileUploadFailed() => new Error("File upload failed",
        ErrorType.InvalidInput, "بارگذاری فایل با خطا مواجه شد");




}