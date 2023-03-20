namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IDomainState
{
    ICollection<IDomainEvent> DomainEvents { get; }
}