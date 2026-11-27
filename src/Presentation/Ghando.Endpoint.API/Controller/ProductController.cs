using Ghando.Service.Contracts;
using Ghando.Service.Products.Contracts;
using Ghando.Service.Products.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ghando.Endpoint.API.Controller;
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<Result<Guid>> AddProductAsync(
        AddProductDto dto, 
        CancellationToken cancellationToken = default)
    {
        var  result = await _productService.CreateProduct(
            dto , 
            cancellationToken);
        
        return result;
    }
}