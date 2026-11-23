namespace Ghando.Entity;

public class Product : Abstract.Entity

{
    public string Name { get; set; } = default!;
    
    public  string? Description { get; set; }
    
    public  string? ImageUrl { get; set; }
    
    public List<ProductCategory> ProductCategories { set; get; } = [];
    
    public List<Comment> Comments { set; get; } = [];
}