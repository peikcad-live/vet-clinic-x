using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians;

public interface IProjectVeterinarianService
{
    Task<Veterinarian?> ProjectBy(LicenseNumber id);
}