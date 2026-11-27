using Ghando.Service.Contracts;
using Ghando.Service.Products.Contracts.Dto;

namespace Ghando.Service.Products.Contracts;

public interface IProductService
{
    Task<Result<Guid>> CreateProduct(
        AddProductDto dto, 
        CancellationToken cancellationToken = default);
}