namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IDomainEvent
{
    Guid EventId { get; }
    
    DateTime Timestamp { get; }
}