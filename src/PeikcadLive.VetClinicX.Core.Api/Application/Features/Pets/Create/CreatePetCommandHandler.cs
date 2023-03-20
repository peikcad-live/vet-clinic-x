using MediatR;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Kernel.Domain;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.Create;

public sealed class CreatePetCommandHandler : IRequestHandler<CreatePetCommand>
{
    private readonly IPetRepository repository;
    private readonly IStateFactory<IPetState> stateFactory;
    private readonly ILogger<CreatePetCommandHandler> logger;

    public CreatePetCommandHandler(IPetRepository repository, IStateFactory<IPetState> stateFactory, ILogger<CreatePetCommandHandler> logger)
    {
        this.repository = repository;
        this.stateFactory = stateFactory;
        this.logger = logger;
    }
    
    public async Task Handle(CreatePetCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var breed = await repository.GetBreedBy(new((uint)command.BreedId), cancellationToken).ConfigureAwait(false);

            if (breed is null)
                throw new ArgumentNullException(nameof(breed));
            
            var pet = Pet.Of(
                AnimalId.DeserializeFrom(command.Id),
                CompleteName.DeserializeFrom(command.CompleteName),
                CustomerCode.DeserializeFrom(command.CompanionId),
                breed,
                stateFactory.Create);

            await repository.Create(pet, cancellationToken).ConfigureAwait(false);
            await repository.Uow.Commit(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            logger.LogError(e, $"{nameof(CreatePetCommandHandler)} failed");
            throw;
        }
    }
}