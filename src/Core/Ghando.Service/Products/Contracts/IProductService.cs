using Ghando.Entity;
using Ghando.Service.Contracts;
using Ghando.Service.Contracts.Dto;
using Ghando.Service.Products.Contracts.Dto;

namespace Ghando.Service.Products.Contracts;

public interface IProductService
{
    Task<Result<Guid>> CreateProduct(
        AddProductDto dto, 
        CancellationToken cancellationToken = default);
    
    Task<Result<PagedListResult<GetProductsDto>>> GetProducts(
        PaginationDto pagination,
        CancellationToken cancellationToken = default);
    
}