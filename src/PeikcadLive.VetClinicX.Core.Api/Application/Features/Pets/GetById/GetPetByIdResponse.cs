using PeikcadLive.VetClinicX.Kernel.Domain;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.GetById;

public record GetPetByIdResponse(string Id, string CompleteName, string CompanionId, int BreedId);