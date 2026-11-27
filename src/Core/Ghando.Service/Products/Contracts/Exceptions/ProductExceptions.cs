using Ghando.Service.Contracts;

namespace Ghando.Service.Products.Contracts.Exceptions;

public static class ProductExceptions
{
    public static  Error CategoryNotFound => new(
        "CategoryNotFound",
        ErrorType.NotFound,
        "یک یا چند دسته‌بندی انتخاب‌شده وجود ندارد.");

    public static Error CategoryRequired() => new Error("CategoryRequired",
        ErrorType.InvalidInput,
        "برای ایجاد محصول، انتخاب حداقل یک دسته‌بندی الزامی است");


}