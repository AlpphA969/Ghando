using Ghando.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.Category;

public class ProductCategoryEntityMap : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Category)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(c => c.CategoryId)
            .IsRequired();
        
    }
}