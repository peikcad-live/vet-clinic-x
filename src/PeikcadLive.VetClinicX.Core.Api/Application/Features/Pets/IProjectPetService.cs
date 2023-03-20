using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets;

public interface IProjectPetService
{
    Task<Pet?> ProjectBy(AnimalId id);
}