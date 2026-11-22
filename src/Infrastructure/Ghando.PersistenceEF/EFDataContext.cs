using Microsoft.EntityFrameworkCore;

namespace Ghando.PersistenceEF;

public class EFDataContext :DbContext
{
    public EFDataContext(DbContextOptions<EFDataContext> options):base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
    }
    
}