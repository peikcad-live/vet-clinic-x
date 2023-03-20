using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure;

public sealed class NoOpEventBus : IDomainEventBus
{
    public Task Publish(IDomainEvent @event, CancellationToken cancellationToken = default) => Task.CompletedTask;
}