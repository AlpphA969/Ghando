using Ghando.Service.Products.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ghando.PersistenceEF.Product;

public class ProductRepository : IProductsRepository
{
    private readonly DbSet<Entity.Product> _products;
    
    public ProductRepository(EFDataContext context)
    {
        _products = context.Set<Entity.Product>();
    }
    
    public async Task<Guid> AddProduct(Entity.Product product,
        CancellationToken cancellationToken = default)
    {
        var result = await _products.AddAsync(product,
            cancellationToken);
        
        return result.Entity.Id; 
    }
}