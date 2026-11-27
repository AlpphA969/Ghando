using Ghando.Entity;

namespace Ghando.Service.Products.Contracts.Dto;

public class GetProductsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public List<Guid> Categories { get; set; } = [];
    
    public string? ImageUrl { get; set; }
    
}