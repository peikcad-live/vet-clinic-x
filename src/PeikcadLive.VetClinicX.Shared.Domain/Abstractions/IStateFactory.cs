namespace PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

public interface IStateFactory<out T>
    where T : IDomainState
{
    T Create();
}