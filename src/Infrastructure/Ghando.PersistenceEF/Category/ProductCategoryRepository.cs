using Ghando.Entity;
using Ghando.Service.ProductCategories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ghando.PersistenceEF.Category;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly DbSet<ProductCategory> _productCategories; 
    
    public ProductCategoryRepository(DbContext context)
    {
        _productCategories = context.Set<ProductCategory>();
    }
    
    public async Task<Guid> AddProductCategoryAsync(ProductCategory prouctCategory, 
        CancellationToken cancellationToken = default)
    {
        var result  = await _productCategories.
            AddAsync(prouctCategory, cancellationToken);

        return result.Entity.Id; 
    }

    public void DeleteProductCategory(ProductCategory prouctCategory)
    {
        _productCategories.Remove(prouctCategory);
    }

    public async Task<List<ProductCategory>> GetProductCategoriesByProductIdAsync(Guid productId, 
        CancellationToken cancellationToken = default)
    {
      List<ProductCategory>  result = await _productCategories
          .Where(p => p.ProductId == productId)
          .ToListAsync(cancellationToken);

      return result;
    }
}