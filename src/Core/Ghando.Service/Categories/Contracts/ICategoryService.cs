using Ghando.Service.Categories.Contracts.Dto;
using Ghando.Service.Contracts;

namespace Ghando.Service.Categories.Contracts;

public interface ICategoryService
{
    Task<Result<Guid>>  AddAsync(
        AddCategoryDto dto,
        CancellationToken cancellationToken = default);
    
    
    
}