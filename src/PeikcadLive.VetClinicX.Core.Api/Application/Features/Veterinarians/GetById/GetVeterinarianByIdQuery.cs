using MediatR;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.GetById;

public record GetVeterinarianByIdQuery(string Id) : IRequest<GetVeterinarianByIdResponse?>;