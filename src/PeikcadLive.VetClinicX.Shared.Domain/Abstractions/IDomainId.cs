namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IDomainId
{
    bool IsSameAs(IDomainId compared);
}