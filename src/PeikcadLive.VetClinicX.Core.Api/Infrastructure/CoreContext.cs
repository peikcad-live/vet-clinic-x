using Microsoft.EntityFrameworkCore;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;
using PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure;

public sealed class CoreContext : DbContext, IUnitOfWork
{
    private readonly IDomainEventBus eventBus;

    public CoreContext(DbContextOptions<CoreContext> options, IDomainEventBus eventBus) : base(options)
    {
        this.eventBus = eventBus;
    }

    public DbSet<CustomerState> Customers { get; init; } = null!;

    public DbSet<VeterinarianState> Veterinarians { get; init; } = null!;

    public DbSet<PetState> Pets { get; init; } = null!;

    public DbSet<BreedState> Breeds { get; init; } = null!;

    public DbSet<SpeciesState> Species { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public async Task Commit(CancellationToken cancellationToken = default)
    {
        var entitiesWithChanges = ChangeTracker.Entries<IDomainState>()
            .Where(e => e.State != EntityState.Unchanged)
            .ToArray();
        
        await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        var events = entitiesWithChanges.SelectMany(e => e.Entity.DomainEvents);
        
        foreach (var @event in events)
            await eventBus.Publish(@event, cancellationToken).ConfigureAwait(false);

        foreach (var entityWithChanges in entitiesWithChanges)
            entityWithChanges.Entity.DomainEvents.Clear();
    }
}