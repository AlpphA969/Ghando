using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.Comment;

public class CommentEntityMap :IEntityTypeConfiguration<Entity.Comment>
{
    public void Configure(EntityTypeBuilder<Entity.Comment> builder)
    {
        builder.ToTable("Comment");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).IsRequired();
        
        builder.Property(x => x.LastName).IsRequired();

        builder.Property(x => x.Status);
        
        builder.Property(x => x.Text).IsRequired();
        
        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);
        
    }
}