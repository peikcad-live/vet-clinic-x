using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Shared.Domain;

public abstract class DomainEntity : IDomainEntity
{
    protected DomainEntity(IDomainState state, IDomainId id)
    {
        EntityState = state;
        Id = id;
    }

    public IDomainState EntityState { get; }

    public IDomainId Id { get; }

    public bool IsSameAs(IDomainEntity compared) => compared is DomainEntity entity && entity.Id.IsSameAs(Id);

    protected void Raise(IDomainEvent domainEvent) => EntityState.DomainEvents.Add(domainEvent);

    public override string ToString() => $"{GetType().Name}::{Id}";
}

public abstract class DomainEntity<TId, TState> : DomainEntity
    where TId : IDomainId
    where TState : IDomainState
{
    protected DomainEntity(TState state, TId id) : base(state, id)
    {
    }

    public TState GetStateAs() => (TState) EntityState;

    public T GetStateAs<T>() where T : TState => (T) EntityState;

    public TId GetIdAs() => (TId) Id;
}