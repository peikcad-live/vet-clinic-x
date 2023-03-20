using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.Create;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.GetById;
using PeikcadLive.VetClinicX.Kernel.Domain;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers;

[ApiController]
[Route("[controller]")]
public sealed class CustomersController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}", Name = "GetCustomerById")]
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
    {
        var customer = await mediator.Send(new GetCustomerByIdQuery(id), cancellationToken);
        
        return customer is not null ? Ok(customer) : NotFound();
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<IActionResult> Post(CustomerModel payload, CancellationToken cancellationToken)
    {
        await mediator.Send(
            new CreateCustomerCommand(
                payload.Id,
                new CompleteName(
                    payload.CompleteName.Name,
                    payload.CompleteName.Surname,
                    payload.CompleteName.PersonalTreatment is not null ? new(payload.CompleteName.PersonalTreatment) : null).ToString(),
                new UsPhoneNumber(payload.ContactPhone.AreaCode, payload.ContactPhone.CentralOfficeCode, payload.ContactPhone.Number).ToString(),
                payload.ContactEmail),
            cancellationToken);

        return CreatedAtRoute("GetCustomerById", new {id = payload.Id}, null);
    }
}