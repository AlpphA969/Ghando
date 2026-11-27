using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Http;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;

namespace Ghando.Service.Products.Contracts.Dto;

public class AddProductDto
{
    [Required ,StringLength(100)] 
    public string Name { get; set; } = default!;    
    
    [StringLength(4000)]
    public string? Description { get; set; }
    
    public List<Guid> CategoryIds { get; set; } = [];
    
    public IFormFile? File { get; set; } 
    
    

}