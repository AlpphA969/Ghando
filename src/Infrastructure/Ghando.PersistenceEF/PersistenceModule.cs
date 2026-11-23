using Autofac;
using Ghando.Service;

namespace Ghando.PersistenceEF;
public class PersistenceModule :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(PersistenceModule).Assembly;
        builder.RegisterAssemblyTypes(assembly)
            .Where(type => type.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        
         
        builder.RegisterType<EFUnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
        
    }
    
}