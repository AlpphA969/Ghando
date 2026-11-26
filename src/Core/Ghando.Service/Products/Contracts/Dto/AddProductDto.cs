using System.ComponentModel.DataAnnotations;

namespace Ghando.Service.Products.Dto;

public class AddProductDto
{
    [Required ,StringLength(100)] 
    public string Name { get; set; } = default!;    
    
    [StringLength(4000)]
    public string? Description { get; set; }
    
    public List<Guid> CategoryIds { get; set; } = [];

}