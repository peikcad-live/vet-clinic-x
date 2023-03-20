using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public sealed class PetVetAssigned : IDomainEvent
{
    public PetVetAssigned(Pets.Pet pet, LicenseNumber veterinarianId)
    {
        PetId = pet.GetIdAs().ToString();
        VeterinarianId = veterinarianId.ToString();
    }
    
    public Guid EventId { get; }
    
    public DateTime Timestamp { get; }
    
    public string PetId { get; }
    
    public string VeterinarianId { get; }
}