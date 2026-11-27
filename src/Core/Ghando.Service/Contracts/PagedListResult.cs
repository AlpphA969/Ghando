namespace Ghando.Service.Contracts;

public class PagedListResult<T>
{
    public List<T> Items { get; set; } = new();
    
    public int TotalItems { get; set; } = default!;
    
    public int TotalPages { get; set; } = default!;
}