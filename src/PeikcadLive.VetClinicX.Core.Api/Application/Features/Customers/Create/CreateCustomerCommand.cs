using MediatR;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.Create;

public sealed record CreateCustomerCommand(
    string Id,
    string CompleteName,
    string ContactPhone,
    string ContactEmail)
: IRequest;