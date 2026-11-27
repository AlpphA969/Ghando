using Ghando.PersistenceEF.Extensions;
using Ghando.Service.Contracts;
using Ghando.Service.Contracts.Dto;
using Ghando.Service.Products.Contracts;
using Ghando.Service.Products.Contracts.Dto;
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

    public async Task<PagedListResult<GetProductsDto>> GetProducts(
        PaginationDto pagination,
        CancellationToken cancellationToken = default)
    {
        return await _products.Select(p => new GetProductsDto
            {
                Id = p.Id,
                
                Name = p.Name,
                
                ImageUrl = p.ImageUrl,
                
                Description = p.Description,
                
                Categories = p.ProductCategories.Select( pc => pc.CategoryId).ToList()
            })
            .ToPagedListAsync(pagination, cancellationToken);
    }
}