using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;

public sealed class VeterinarianStateFactory : IStateFactory<IVeterinarianState>
{
    public IVeterinarianState Create() => new VeterinarianState();
}