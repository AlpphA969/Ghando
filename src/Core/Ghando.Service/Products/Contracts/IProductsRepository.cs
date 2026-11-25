namespace Ghando.Service.Products.Contracts;

public interface IProductsRepository
{
    public  Task<Guid> AddProduct(Entity.Product product , 
        CancellationToken cancellationToken = default);
}