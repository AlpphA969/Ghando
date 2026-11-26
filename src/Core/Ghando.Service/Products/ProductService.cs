using Ghando.Entity;
using Ghando.Service.Categories.Contracts;
using Ghando.Service.Contracts;
using Ghando.Service.Products.Contracts;
using Ghando.Service.Products.Contracts.Exceptions;
using Ghando.Service.Products.Dto;

namespace Ghando.Service.Products;

public class ProductService : IProductService
{
    private  readonly  IProductsRepository _repository;
    
    private  readonly  IUnitOfWork _unitOfWork;
    
    private readonly ICategoryRepository _categories;

    public ProductService(
        IProductsRepository repository, 
        IUnitOfWork unitOfWork ,  
        ICategoryRepository categories)
    {
        _repository = repository;
         
        _unitOfWork = unitOfWork;
        
        _categories =   categories;
    }
    
    
    
    public async Task<Result<Guid>> CreateProduct(
        AddProductDto dto, 
        CancellationToken cancellationToken = default)
    {
        
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

        var id = await _repository.AddProduct(
            product, 
            cancellationToken);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return id;
    }

}