using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public class PetState : IPetState
{
    public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public string Id { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string HumanCompanionId { get; set; } = string.Empty;
    
    public string? VeterinarianId { get; set; }
    
    public int BreedId { get; set; }

    public IBreedState Breed
    {
        get => InnerBreed;
        set => InnerBreed = (BreedState)value;
    }

    internal BreedState InnerBreed { get; set; } = null!;
}