namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IDomainEntity
{
    IDomainState EntityState { get; }
    
    IDomainId Id { get; }
    
    bool IsSameAs(IDomainEntity compared);
}