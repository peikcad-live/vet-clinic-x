using Microsoft.EntityFrameworkCore;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Veterinarians;

public sealed class VeterinarianRepository : IVeterinarianRepository
{
    private readonly CoreContext context;

    public VeterinarianRepository(CoreContext context)
    {
        this.context = context;
    }

    public IUnitOfWork Uow => context;

    public async Task<Veterinarian?> GetBy(LicenseNumber id, CancellationToken cancellationToken = default)
    {
        var state = await context.Veterinarians.SingleOrDefaultAsync(v => v.Id == id.ToString(), cancellationToken).ConfigureAwait(false);

        return state is not null ? Veterinarian.RehydrateFrom(state) : null;
    }

    public async Task Create(Veterinarian veterinarian, CancellationToken cancellationToken = default)
        => await context.Veterinarians.AddAsync(veterinarian.GetStateAs<VeterinarianState>(), cancellationToken).ConfigureAwait(false);
}