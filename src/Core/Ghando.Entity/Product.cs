namespace Ghando.Entity;

public class Product : Abstract.Entity

{
    public  string Name { get; set; }
    
    public  string Description { get; set; }
    
    public  string imageUrl { get; set; }
    
    public List<ProductCategory> ProductCategories { set; get; } = [];
    
    public List<Comment> Comments { set; get; } = [];
}