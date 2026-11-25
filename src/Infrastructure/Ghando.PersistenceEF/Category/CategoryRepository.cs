using Ghando.Service.Categories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ghando.PersistenceEF.Category;

public class CategoryRepository  : ICategoryRepository
{
    private  readonly DbSet<Entity.Category> _categories;
    
    public CategoryRepository(EFDataContext dbContext)
    {
        _categories = dbContext.Set<Entity.Category>();
    }

    public async Task<Guid> AddAsync(
        Entity.Category category,
        CancellationToken cancellationToken = default)
    {
        var result = await _categories.AddAsync(category,
            cancellationToken);
        
        return result.Entity.Id;
    }

    public async Task<int> CountByIdsAsync(
        List<Guid> ids,
        CancellationToken cancellationToken = default) {
        
        var result =  await _categories.CountAsync(c =>  ids.Contains(c.Id),
            cancellationToken);
        return result;
    }
         




}