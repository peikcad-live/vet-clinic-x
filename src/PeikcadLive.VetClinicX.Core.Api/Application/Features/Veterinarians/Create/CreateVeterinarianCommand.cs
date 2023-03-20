using MediatR;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.Create;

public sealed record CreateVeterinarianCommand(
    string Id,
    string CompleteName,
    string ContactPhone,
    string ContactEmail)
: IRequest;