using MediatR;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;
using PeikcadLive.VetClinicX.Kernel.Domain;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.Create;

public sealed class CreateVeterinarianCommandHandler : IRequestHandler<CreateVeterinarianCommand>
{
    private readonly IVeterinarianRepository repository;
    private readonly IStateFactory<IVeterinarianState> stateFactory;
    private readonly ILogger<CreateVeterinarianCommandHandler> logger;

    public CreateVeterinarianCommandHandler(IVeterinarianRepository repository, IStateFactory<IVeterinarianState> stateFactory, ILogger<CreateVeterinarianCommandHandler> logger)
    {
        this.repository = repository;
        this.stateFactory = stateFactory;
        this.logger = logger;
    }
    
    public async Task Handle(CreateVeterinarianCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var veterinarian = Veterinarian.Of(
                LicenseNumber.DeserializeFrom(command.Id),
                CompleteName.DeserializeFrom(command.CompleteName),
                UsPhoneNumber.DeserializeFrom(command.ContactPhone),
                CorporateEmail.DeserializeFrom(command.ContactEmail),
                stateFactory.Create);
            
            await repository.Create(veterinarian, cancellationToken).ConfigureAwait(false);
            await repository.Uow.Commit(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            logger.LogError(e, $"{nameof(CreateVeterinarianCommandHandler)} failed");
            throw;
        }
    }
}