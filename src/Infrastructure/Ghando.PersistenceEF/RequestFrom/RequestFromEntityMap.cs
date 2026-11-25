using Ghando.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ghando.PersistenceEF.RequestFrom;

public class RequestFromEntityMap : IEntityTypeConfiguration<RequestForm>
{
    public void Configure(EntityTypeBuilder<RequestForm> builder)
    {
        builder.ToTable("RequestForms");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        
        builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();

        builder.Property(x => x.Text).HasMaxLength(4000).IsRequired();
        
        builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();

        builder.Property(x => x.Subject).HasMaxLength(200).IsRequired();

        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.Status);
       
        
    }
}