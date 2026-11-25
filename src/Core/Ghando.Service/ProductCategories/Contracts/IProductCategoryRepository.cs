using Ghando.Entity;

namespace Ghando.Service.ProductCategories.Contracts;

public interface IProductCategoryRepository
{
    Task<Guid>  AddProductCategoryAsync(ProductCategory prouctCategory , 
        CancellationToken cancellationToken = default);
    
    void DeleteProductCategory(ProductCategory prouctCategory);
    
    Task<List<ProductCategory>> GetProductCategoriesByProductIdAsync(
        Guid productId,
        CancellationToken cancellationToken = default);
    
    
}