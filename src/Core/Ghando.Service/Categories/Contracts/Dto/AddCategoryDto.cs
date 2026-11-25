using System.ComponentModel.DataAnnotations;

namespace Ghando.Service.Categories.Contracts.Dto;

public class AddCategoryDto
{
    [Required] 
    public string Title { get; set; } = default!;
    
    
}