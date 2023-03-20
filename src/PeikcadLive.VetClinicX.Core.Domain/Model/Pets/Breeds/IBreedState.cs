using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;

public interface IBreedState : IDomainState
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int SpeciesId { get; set; }
    
    public ISpeciesState Species { get; set; }
}