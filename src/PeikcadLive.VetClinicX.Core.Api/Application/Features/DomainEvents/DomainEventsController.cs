using Microsoft.AspNetCore.Mvc;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.DomainEvents;

[ApiController]
[Route("[controller]")]
public class DomainEventsController : ControllerBase
{
    private readonly IDomainEventBus eventBus;

    public DomainEventsController(IDomainEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    [HttpPost("petvetselected", Name = "Raise a PetVetSelected domain event")]
    public async Task<IActionResult> Post(PetVetSelected @event, CancellationToken cancellationToken)
    {
        await eventBus.Publish(@event, cancellationToken);
        return NoContent();
    }
}