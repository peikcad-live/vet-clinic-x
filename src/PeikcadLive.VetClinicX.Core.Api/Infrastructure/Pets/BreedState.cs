using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class BreedState : IBreedState
{
    public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();
    
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public int SpeciesId { get; set; }

    public ISpeciesState Species
    {
        get => InnerSpecies;
        set => InnerSpecies = (SpeciesState)value;
    }

    internal SpeciesState InnerSpecies { get; set; } = null!;
}