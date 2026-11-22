using Autofac;

namespace Ghando.Service;

public class ServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = typeof(ServiceModule).Assembly;
        builder.RegisterAssemblyTypes(assembly)
            .Where(type => type.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}