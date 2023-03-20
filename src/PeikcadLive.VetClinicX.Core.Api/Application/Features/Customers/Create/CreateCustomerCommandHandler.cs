using MediatR;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Kernel.Domain;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository repository;
    private readonly IStateFactory<ICustomerState> stateFactory;
    private readonly ILogger<CreateCustomerCommandHandler> logger;

    public CreateCustomerCommandHandler(ICustomerRepository repository, IStateFactory<ICustomerState> stateFactory, ILogger<CreateCustomerCommandHandler> logger)
    {
        this.repository = repository;
        this.stateFactory = stateFactory;
        this.logger = logger;
    }
    
    public async Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var customer = Customer.Of(
                CustomerCode.DeserializeFrom(command.Id),
                CompleteName.DeserializeFrom(command.CompleteName),
                UsPhoneNumber.DeserializeFrom(command.ContactPhone),
                PublicEmail.DeserializeFrom(command.ContactEmail),
                stateFactory.Create);

            await repository.Create(customer, cancellationToken).ConfigureAwait(false);
            await repository.Uow.Commit(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            logger.LogError(e, $"{nameof(CreateCustomerCommandHandler)} failed");
            throw;
        }
    }
}