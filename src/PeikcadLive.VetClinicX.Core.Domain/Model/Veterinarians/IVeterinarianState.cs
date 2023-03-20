namespace PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

public interface IVeterinarianState : IDomainState
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string ContactPhone { get; set; }
    
    public string ContactEmail { get; set; }
}