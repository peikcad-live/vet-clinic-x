using MediatR;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.GetById;

public sealed class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, GetPetByIdResponse?>
{
    private readonly IProjectPetService projector;

    public GetPetByIdQueryHandler(IProjectPetService projector)
    {
        this.projector = projector;
    }
    
    public async Task<GetPetByIdResponse?> Handle(GetPetByIdQuery query, CancellationToken cancellationToken)
    {
        var id = AnimalId.DeserializeFrom(query.Id);
        var pet = await projector.ProjectBy(id);

        return pet is not null
            ? new GetPetByIdResponse(
                pet.GetIdAs().ToString(),
                pet.Name.ToString(),
                pet.HumanCompanion.ToString(),
                (int)pet.Breed.GetIdAs().Value)
            : null;
    }
}