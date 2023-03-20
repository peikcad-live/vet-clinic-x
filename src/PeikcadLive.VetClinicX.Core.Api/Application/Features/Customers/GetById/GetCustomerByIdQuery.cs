using MediatR;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.GetById;

public record GetCustomerByIdQuery(string Id) : IRequest<GetCustomerByIdResponse?>;