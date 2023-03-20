using Microsoft.EntityFrameworkCore;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets.Seeds;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.EventHandlers;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreModel(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CoreContext>(c
            => c.UseSqlServer(configuration.GetConnectionString("Default")));

        services.AddScoped<ICustomerRepository, CustomerRepository>()
            .AddTransient<IStateFactory<ICustomerState>, CustomerStateFactory>()
            .AddScoped<IProjectCustomerService, ProjectCustomerService>();

        services.AddScoped<IVeterinarianRepository, VeterinarianRepository>()
            .AddTransient<IStateFactory<IVeterinarianState>, VeterinarianStateFactory>()
            .AddScoped<IProjectVeterinarianService, ProjectVeterinarianService>();

        services.AddScoped<IPetRepository, PetRepository>()
            .AddTransient<IStateFactory<IPetState>, PetStateFactory>()
            .AddScoped<IProjectPetService, ProjectPetService>();

        return services;
    }

    public static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IDomainEventBus, EventBus>()
            .AddHostedService<DomainEventProcessor>();
        
        services.AddScoped<IDomainEventHandler<PetVetSelected>, PetVetSelectedHandler>();

        return services;
    }

    public static async Task UseSeed(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<CoreContext>();

        await context.Database.MigrateAsync();

        if (false == await context.Species.AnyAsync())
            await context.Species.AddRangeAsync(SpeciesSeed.All);

        if (false == await context.Breeds.AnyAsync())
            await context.Breeds.AddRangeAsync(BreedsSeed.All);

        await context.SaveChangesAsync();
    }
}