using MediatR;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.GetById;

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse?>
{
    private readonly IProjectCustomerService projector;

    public GetCustomerByIdQueryHandler(IProjectCustomerService projector)
    {
        this.projector = projector;
    }
    
    public async Task<GetCustomerByIdResponse?> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken = default)
    {
        var id = CustomerCode.DeserializeFrom(query.Id);
        var customer = await projector.ProjectBy(id);

        return customer is not null
            ? new GetCustomerByIdResponse(
                customer.GetIdAs().ToString(),
                customer.Name.ToString(),
                customer.ContactPhone.ToString(),
                customer.ContactEmail.ToString())
            : null;
    }
}