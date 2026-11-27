using Ghando.Entity;

namespace Ghando.Service.RequestForms.Contracts;

public interface IRequestFormRepository
{
    Task<Guid> AddRequestFormAsync(
        RequestForm requestForm , 
        CancellationToken  cancellationToken =  default);
}