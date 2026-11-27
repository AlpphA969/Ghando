using System.ComponentModel.DataAnnotations;

namespace Ghando.Service.RequestForms.Contracts.Dto;

public class AddRequestFormDto
{
    [Required , StringLength(100)]
    public string FirstName { get; set; }
    
    [Required , StringLength(4000)]
    public string Text { get; set; }
    
    [Required , StringLength(100)]
    public string LastName { get; set; }
    
    [Required , StringLength(200)]
    public string Subject { get; set; }
    
    [Required ,  StringLength(11)]
    public string PhoneNumber { get; set; }
}