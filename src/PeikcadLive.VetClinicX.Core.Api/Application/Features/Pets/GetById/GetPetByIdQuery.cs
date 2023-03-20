using MediatR;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.GetById;

public record GetPetByIdQuery(string Id) : IRequest<GetPetByIdResponse?>;