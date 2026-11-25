using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.Comment;

public class CommentEntityMap :IEntityTypeConfiguration<Entity.Comment>
{
    public void Configure(EntityTypeBuilder<Entity.Comment> builder)
    {
        builder.ToTable("Comments");
        
        builder.HasKey(x => x.Id);

        builder
            .HasOne(c => c.Product)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.ProductId)
            .IsRequired();

        builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        
        builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();

        builder.Property(x => x.Status);
        
        builder.Property(x => x.Text).HasMaxLength(2000).IsRequired();
        
        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);
        
    }
}