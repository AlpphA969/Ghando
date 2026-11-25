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

    public async Task<bool> CategoryExistAsync(string title,
        CancellationToken cancellationToken = default)
    {
        var result = await _categories.Where(c => c.Title == title).
            AnyAsync(cancellationToken);

        return result;
    }

    public async Task<Entity.Category?> GetCategoryByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var result =  await _categories.FirstOrDefaultAsync(c => c.Id == id);
        
        return result;
    }

    public Task<bool> CategoryExistExceptAsync(string title, 
        Guid exceptCategoryId, CancellationToken cancellationToken = default)
    {
        var  result =  _categories.
            Where(c => c.Title == title &&  c.Id  != exceptCategoryId).
            AnyAsync(cancellationToken);
        
        return result;
    }

    public void DeleteCategory(Entity.Category category)
    {
        _categories.Remove(category); 
    }
}