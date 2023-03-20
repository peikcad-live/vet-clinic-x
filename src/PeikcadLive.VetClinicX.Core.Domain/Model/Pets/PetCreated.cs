namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public sealed class PetCreated : IDomainEvent
{
    public PetCreated(Pets.Pet pet)
    {
        Id = pet.GetIdAs().ToString();
        Name = pet.GetStateAs().Name;
        HumanCompanionId = pet.GetStateAs().HumanCompanionId;
    }
    
    public Guid EventId { get; } = Guid.NewGuid();
    
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    
    public string Id { get; }
    
    public string Name { get; }
    
    public string HumanCompanionId { get; }
}