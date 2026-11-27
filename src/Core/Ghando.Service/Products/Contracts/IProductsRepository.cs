using Ghando.Entity;
using Ghando.Service.Contracts;
using Ghando.Service.Contracts.Dto;
using Ghando.Service.Products.Contracts.Dto;

namespace Ghando.Service.Products.Contracts;

public interface IProductsRepository
{
    public  Task<Guid> AddProduct(
        Entity.Product product , 
        CancellationToken cancellationToken = default);
    
    Task<PagedListResult<GetProductsDto>> GetProducts(
        PaginationDto pagination,
        CancellationToken cancellationToken = default);
        
}