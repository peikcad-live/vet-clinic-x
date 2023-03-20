using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public interface IPetState : IDomainState
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string HumanCompanionId { get; set; }
    
    public string? VeterinarianId { get; set; }
    
    public int BreedId { get; set; }
    
    public IBreedState Breed { get; set; }
}