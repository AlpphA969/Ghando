namespace Ghando.Entity;

public class Category : Abstract.Entity
{
    public string Title { set; get; } = default!;

    public List<ProductCategory> ProductCategories { set; get; } = [];

}