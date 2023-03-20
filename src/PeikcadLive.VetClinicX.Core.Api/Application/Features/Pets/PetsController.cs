using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.Create;
using PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.GetById;
using PeikcadLive.VetClinicX.Kernel.Domain;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets;

[ApiController]
[Route("[controller]")]
public sealed class PetsController : ControllerBase
{
    private readonly IMediator mediator;

    public PetsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}", Name = "GetPetById")]
    public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
    {
        var pet = await mediator.Send(new GetPetByIdQuery(id), cancellationToken);
        
        return pet is not null ? Ok(pet) : NotFound();
    }

    [HttpPost(Name = "CreatePet")]
    public async Task<IActionResult> Post(PetModel payload, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreatePetCommand(
                payload.Id,
                new CompleteName(
                    payload.CompleteName.Name,
                    payload.CompleteName.Surname,
                    payload.CompleteName.PersonalTreatment is not null ? new PersonalTreatment(payload.CompleteName.PersonalTreatment) : null).ToString(),
                payload.CompanionId,
                payload.BreedId),
            cancellationToken);
        
        return CreatedAtRoute("GetPetById", new {id = payload.Id}, null);
    }
}