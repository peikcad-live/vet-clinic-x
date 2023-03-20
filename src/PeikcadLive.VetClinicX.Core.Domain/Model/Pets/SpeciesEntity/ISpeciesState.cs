namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;

public interface ISpeciesState : IDomainState
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}