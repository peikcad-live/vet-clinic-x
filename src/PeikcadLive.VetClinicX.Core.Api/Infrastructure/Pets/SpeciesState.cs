using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class SpeciesState : ISpeciesState
{
    public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();
    
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}