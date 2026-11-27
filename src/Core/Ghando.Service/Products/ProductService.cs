using Ghando.Entity;
using Ghando.Service.Categories.Contracts;
using Ghando.Service.Contracts;
using Ghando.Service.FileService.Contracts;
using Ghando.Service.FileService.Contracts.Exceptions;
using Ghando.Service.Products.Contracts;
using Ghando.Service.Products.Contracts.Dto;
using Ghando.Service.Products.Contracts.Exceptions;

namespace Ghando.Service.Products;

public class ProductService : IProductService
{
    private  readonly  IProductsRepository _repository;
    private  readonly  IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categories;
    
    private readonly IFileService _fileService;

    public ProductService(
        IProductsRepository repository, 
        IUnitOfWork unitOfWork ,  
        ICategoryRepository categories, IFileService fileService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _categories =   categories;
        _fileService = fileService;
    }
    
    
    
    public async Task<Result<Guid>> CreateProduct(
        AddProductDto dto, 
        CancellationToken cancellationToken = default)
    {

        if (dto.CategoryIds.Count == 0)
        {
            return ProductExceptions.CategoryRequired();
        }
        
        var categoryIds =   dto.CategoryIds.Distinct().ToList();

        var categoriesCount = await _categories.CountByIdsAsync(
            categoryIds, 
            cancellationToken);
        
        if (categoriesCount != categoryIds.Count)
        {
            return ProductExceptions.CategoryNotFound;
        }

        var product = new Product
        {
            Name = dto.Name,

            Description = dto.Description,

            ProductCategories = categoryIds.Select(id => new ProductCategory
            {
                CategoryId = id
            }).ToList()

        };
        
        if (dto.File != null)
        {
            var uploadFileResult = await _fileService.UploadFile(dto.File);

            if (!uploadFileResult.IsSuccess)
            {
                
                return FileExceptions.FileUploadFailed();
            }
            
            product.ImageUrl = uploadFileResult.Value;


        }

        var id = await _repository.AddProduct(
            product, 
            cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return id;
    }

}