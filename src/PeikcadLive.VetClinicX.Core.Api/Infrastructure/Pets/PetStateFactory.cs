using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class PetStateFactory : IStateFactory<IPetState>
{
    public IPetState Create() => new PetState();
}