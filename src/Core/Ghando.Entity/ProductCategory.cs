namespace Ghando.Entity;

public class ProductCategory : Abstract.Entity
{
    public Guid ProductId { set; get; }
    
    public Product? Product  { set; get; }
    
    public Guid CategoryId { set; get; }
    
    public Category? Category { set; get; }
    
}