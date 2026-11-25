using System.ComponentModel.DataAnnotations;

namespace Ghando.Service.Categories.Contracts.Dto;

public class AddCateoryDto
{
    [Required] 
    public string Title { get; set; } = default!;
}