using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.Create;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.GetById;
using PeikcadLive.VetClinicX.Kernel.Domain;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians;

[ApiController]
[Route("[controller]")]
public sealed class VeterinariansController : ControllerBase
{
    private readonly IMediator mediator;

    public VeterinariansController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet("{id}", Name = "GetVeterinarianById")]
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
    {
        var veterinarian = await mediator.Send(new GetVeterinarianByIdQuery(id), cancellationToken);
        
        return veterinarian is not null ? Ok(veterinarian) : NotFound();
    }

    [HttpPost(Name = "CreateVeterinarian")]
    public async Task<IActionResult> Post(VeterinarianModel payload, CancellationToken cancellationToken)
    {
        await mediator.Send(
            new CreateVeterinarianCommand(
                payload.Id,
                new CompleteName(
                    payload.CompleteName.Name,
                    payload.CompleteName.Surname,
                    payload.CompleteName.PersonalTreatment is not null ? new PersonalTreatment(payload.CompleteName.PersonalTreatment) : null).ToString(),
                new UsPhoneNumber(payload.ContactPhone.AreaCode, payload.ContactPhone.CentralOfficeCode, payload.ContactPhone.Number).ToString(),
                payload.ContactEmail),
            cancellationToken);

        return CreatedAtRoute("GetVeterinarianById", new {id = payload.Id}, null);
    }
}