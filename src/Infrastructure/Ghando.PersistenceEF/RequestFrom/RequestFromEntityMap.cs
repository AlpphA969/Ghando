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

        builder.Property(x => x.FirstName).IsRequired();
        
        builder.Property(x => x.LastName).IsRequired();

        builder.Property(x => x.Text).IsRequired();
        
        builder.Property(x => x.PhoneNumber).IsRequired();

        builder.Property(x => x.Subject).IsRequired();

        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.Status);
       
        
    }
}