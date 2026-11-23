using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.Product;

public class ProductEntityMap : IEntityTypeConfiguration<Entity.Product>

{
    public void Configure(EntityTypeBuilder<Entity.Product> builder)
    {
        builder.ToTable("Products");    
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description);

        builder.Property(x => x.Name).IsRequired();

        builder.Property(x => x.ImageUrl);

        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);
        
    }
}