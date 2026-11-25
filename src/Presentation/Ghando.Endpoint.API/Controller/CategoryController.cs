using Ghando.Service.Categories.Contracts;
using Ghando.Service.Categories.Contracts.Dto;
using Ghando.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ghando.Endpoint.API.Controller;
[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<Result<Guid>> AddAsync(
        AddCategoryDto dto,
        CancellationToken cancellationToken)
    {
        
        var result = await _service.AddAsync(dto, cancellationToken);
        return result;
        
    }
    
    
}