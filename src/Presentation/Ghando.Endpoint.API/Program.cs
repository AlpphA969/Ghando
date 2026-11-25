using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ghando.PersistenceEF;
using Ghando.Service;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Ghando.Endpoint.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Host.UseServiceProviderFactory(
            new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(container =>
        {
            container.RegisterModule<ServiceModule>();
            container.RegisterModule<PersistenceModule>();
        });
        builder.Services.AddDbContext<EFDataContext>(option =>
            option.UseNpgsql(
                builder.Configuration
                    .GetConnectionString("DefaultConnection")));
        
        builder.Services.AddOpenApi();
        
        builder.Services.AddControllers();

        var app = builder.Build();
        app.UseStaticFiles();
        
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
        

        app.UseHttpsRedirection();
        app.MapControllers();

        app.UseAuthorization();
        app.Run();
    }
}