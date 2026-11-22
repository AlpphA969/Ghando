using Autofac;
using Ghando.Service;

namespace Ghando.PersistenceEF;
public class PersistenceMoudle :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(PersistenceMoudle).Assembly;
        builder.RegisterAssemblyTypes(assembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        
         
        builder.RegisterType<EFUnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
        
    }
    
}