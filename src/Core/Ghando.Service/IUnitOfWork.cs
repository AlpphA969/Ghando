namespace Ghando.Service;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken =  default);

}