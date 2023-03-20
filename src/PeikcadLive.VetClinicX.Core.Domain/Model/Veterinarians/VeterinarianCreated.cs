namespace PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

public sealed class VeterinarianCreated : IDomainEvent
{
    public VeterinarianCreated(Veterinarian veterinarian)
    {
        Id = veterinarian.GetIdAs().ToString();
        Name = veterinarian.GetStateAs().Name;
        ContactPhone = veterinarian.GetStateAs().ContactPhone;
        ContactEmail = veterinarian.GetStateAs().ContactEmail;
    }
    
    public Guid EventId { get; } = Guid.NewGuid();

    public DateTime Timestamp { get; } = DateTime.UtcNow;
    
    public string Id { get; }
    
    public string Name { get; }
    
    public string ContactPhone { get; }
    
    public string ContactEmail { get; }
}