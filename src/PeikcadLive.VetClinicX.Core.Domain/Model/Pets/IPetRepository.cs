using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public interface IPetRepository : IRepository
{
    Task<Pets.Pet?> GetBy(AnimalId id, CancellationToken cancellationToken = default);

    Task<Breed?> GetBreedBy(PositiveNaturalNumber id, CancellationToken cancellationToken = default);

    Task Create(Pets.Pet pet, CancellationToken cancellationToken = default);
}