namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IDomainEventBus
{
    Task Publish(IDomainEvent @event, CancellationToken cancellationToken = default);
}