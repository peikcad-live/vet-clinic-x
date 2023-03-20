using System.Collections.Concurrent;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure;

public sealed class EventBus : IDomainEventBus
{
    private static readonly ConcurrentQueue<IDomainEvent> queue = new();

    public Task Publish(IDomainEvent @event, CancellationToken cancellationToken = default)
    {
        queue.Enqueue(@event);
        return Task.CompletedTask;
    }

    public IDomainEvent? Pop()
    {
        queue.TryDequeue(out var @event);
        return @event;
    }
}