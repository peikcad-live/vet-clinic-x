using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.EventHandlers;

public sealed class PetVetSelectedHandler : IDomainEventHandler<PetVetSelected>
{
    private readonly IPetRepository petRepo;
    private readonly IVeterinarianRepository vetRepo;

    public PetVetSelectedHandler(IPetRepository petRepo, IVeterinarianRepository vetRepo)
    {
        this.petRepo = petRepo;
        this.vetRepo = vetRepo;
    }
    
    public async Task Handle(PetVetSelected @event, CancellationToken cancellationToken = default)
    {
        var petId = new AnimalId(@event.PetId);
        var vetId = new LicenseNumber(@event.VeterinarianId);
        var pet = await petRepo.GetBy(petId, cancellationToken);
        var vet = await vetRepo.GetBy(vetId, cancellationToken);
        
        if (pet is null || vet is null)
            return;

        pet.Assign(vet);
        await petRepo.Uow.Commit(cancellationToken);
    }
}