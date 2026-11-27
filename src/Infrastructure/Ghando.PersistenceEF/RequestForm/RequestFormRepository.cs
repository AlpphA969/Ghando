using Ghando.Service.RequestForms.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ghando.PersistenceEF.RequestForm;

public class RequestFormRepository : IRequestFormRepository

{
    private readonly DbSet<Entity.RequestForm> _requestForms;

    public RequestFormRepository(EFDataContext context)
    {
        _requestForms = context.Set<Entity.RequestForm>();
    }


    public async Task<Guid> AddRequestFormAsync(
        Entity.RequestForm requestForm, 
        CancellationToken cancellationToken = default)
    {
        var result =await _requestForms.AddAsync(requestForm,
            cancellationToken);

        return result.Entity.Id ;

    }
}