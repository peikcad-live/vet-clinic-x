namespace PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

public interface IVeterinarianRepository : IRepository
{
    Task<Veterinarian?> GetBy(LicenseNumber id, CancellationToken cancellationToken = default);

    Task Create(Veterinarian veterinarian, CancellationToken cancellationToken = default);
}