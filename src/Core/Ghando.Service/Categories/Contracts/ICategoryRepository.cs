using Ghando.Entity;

namespace Ghando.Service.Categories.Contracts;

public interface ICategoryRepository
{

    Task<Guid> AddAsync(Category category,
        CancellationToken cancellationToken = default);
    
    Task<int> CountByIdsAsync(
        List<Guid> ids, 
        CancellationToken cancellationToken = default);



}