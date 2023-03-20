using MediatR;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.Create;

public sealed record CreatePetCommand(
    string Id,
    string CompleteName,
    string CompanionId,
    int BreedId)
: IRequest;