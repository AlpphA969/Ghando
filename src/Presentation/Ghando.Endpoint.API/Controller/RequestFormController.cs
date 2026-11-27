using Ghando.Service.Contracts;
using Ghando.Service.RequestForms.Contracts;
using Ghando.Service.RequestForms.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ghando.Endpoint.API.Controller;
[ApiController]
[Route("api/RequestForms")]
public class RequestFormController :  ControllerBase
{
    private readonly IRequestFormService _service;
    
    public RequestFormController(IRequestFormService service)
    {
        this._service = service;
    }

    [HttpPost]
    public async Task<Result<Guid>> AddRequestFormAsync(
        AddRequestFormDto dto,
        CancellationToken cancellationToken = default
    )
    {
        var result = await this._service.AddRequestFormAsync(dto, cancellationToken);
        return result;
    }
    
}