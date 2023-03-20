using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure;

public sealed class CoreContextDesignTimeFactory : IDesignTimeDbContextFactory<CoreContext>
{
    public CoreContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json", false)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();
        
        var options = new DbContextOptionsBuilder<CoreContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"))
            .Options;

        return new(options, new NoOpEventBus());
    }
}