using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.Product;

public class ProductEntityMap : IEntityTypeConfiguration<Entity.Product>

{
    public void Configure(EntityTypeBuilder<Entity.Product> builder)
    {
        builder.ToTable("Products");    
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description).HasMaxLength(4000);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

        builder.Property(x => x.ImageUrl).HasMaxLength(2048);

        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);
        
    }
}