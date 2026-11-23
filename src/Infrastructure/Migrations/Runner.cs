using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Migrations;

class Runner
{
    static void Main()
    {
        var connectionString =
            "Host=localhost;Port=5432;Database=ghando;Username=postgres;Password=P@ssw0rd23";

        using var serviceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddPostgres15_0()
                .WithGlobalCommandTimeout(TimeSpan.FromSeconds(300))
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Runner).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        using var scope = serviceProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<IMigrationRunner>()
            .MigrateUp();
    }
}
    
    