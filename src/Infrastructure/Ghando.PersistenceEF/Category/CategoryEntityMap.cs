using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.Category;

public class CategoryEntityMap :IEntityTypeConfiguration<Entity.Category>
{
    public void Configure(EntityTypeBuilder<Entity.Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);;

        builder.Property(c => c.CreatedAt);
        
        builder.Property(c => c.UpdatedAt);
        
        
    }
}