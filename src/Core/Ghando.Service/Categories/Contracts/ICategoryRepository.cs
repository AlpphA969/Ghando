using Ghando.Entity;

namespace Ghando.Service.Categories.Contracts;

public interface ICategoryRepository
{

    Task<Guid> AddAsync(Category category,
        CancellationToken cancellationToken = default);

    Task<bool> CategoryExistAsync(string title,
        CancellationToken cancellationToken = default);
    

    
    Task<Category?>  GetCategoryByIdAsync (Guid id,
        CancellationToken cancellationToken = default);
    
    Task<bool>  CategoryExistExceptAsync ( string title,  
        Guid exceptCategoryId, CancellationToken cancellationToken = default) ;

    void DeleteCategory(Category category);

}