using Microsoft.EntityFrameworkCore;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;
using PeikcadLive.VetClinicX.Kernel.Domain;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Pets;

public sealed class PetRepository : IPetRepository
{
    private readonly CoreContext context;

    public PetRepository(CoreContext context)
    {
        this.context = context;
    }

    public IUnitOfWork Uow => context;
    
    public async Task<Pet?> GetBy(AnimalId id, CancellationToken cancellationToken = default)
    {
        var state = await context.Pets.SingleOrDefaultAsync(p => p.Id == id.ToString(), cancellationToken).ConfigureAwait(false);

        return state is not null ? Pet.RehydrateFrom(state) : null;
    }

    public async Task<Breed?> GetBreedBy(PositiveNaturalNumber id, CancellationToken cancellationToken = default)
    {
        var state = await context.Breeds.SingleOrDefaultAsync(b => b.Id == id.Value, cancellationToken).ConfigureAwait(false);

        return state is not null ? Breed.RehydrateFrom(state) : null;
    }

    public async Task Create(Pet pet, CancellationToken cancellationToken = default)
        => await context.Pets.AddAsync(pet.GetStateAs<PetState>(), cancellationToken);
}