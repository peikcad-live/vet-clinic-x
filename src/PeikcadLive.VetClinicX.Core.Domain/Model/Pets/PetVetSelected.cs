namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public sealed class PetVetSelected : IDomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();

    public DateTime Timestamp { get; init; } = DateTime.UtcNow;

    public string PetId { get; init; } = string.Empty;

    public string VeterinarianId { get; init; } = string.Empty;
}