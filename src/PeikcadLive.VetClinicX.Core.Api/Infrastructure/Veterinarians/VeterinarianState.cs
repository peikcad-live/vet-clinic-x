using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;

public sealed class VeterinarianState : IVeterinarianState
{
    public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public string Id { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string ContactPhone { get; set; } = string.Empty;
    
    public string ContactEmail { get; set; } = string.Empty;
}