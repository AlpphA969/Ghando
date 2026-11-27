using Ghando.Service.Categories.Contracts.Dto;
using Ghando.Service.Contracts;
using Ghando.Service.RequestForms.Contracts.Dto;

namespace Ghando.Service.RequestForms.Contracts;

public interface IRequestFormService
{
    Task<Result<Guid>> AddRequestFormAsync(
        AddRequestFormDto dto,
        CancellationToken cancellationToken = default);
}