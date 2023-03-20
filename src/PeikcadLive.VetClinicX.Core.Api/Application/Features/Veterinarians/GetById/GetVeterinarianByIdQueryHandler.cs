using MediatR;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.GetById;

public sealed class GetVeterinarianByIdQueryHandler : IRequestHandler<GetVeterinarianByIdQuery, GetVeterinarianByIdResponse?>
{
    private readonly IProjectVeterinarianService projector;

    public GetVeterinarianByIdQueryHandler(IProjectVeterinarianService projector)
    {
        this.projector = projector;
    }
    
    public async Task<GetVeterinarianByIdResponse?> Handle(GetVeterinarianByIdQuery query, CancellationToken cancellationToken)
    {
        var id = LicenseNumber.DeserializeFrom(query.Id);
        var vet = await projector.ProjectBy(id);
        
        return vet is not null
            ? new GetVeterinarianByIdResponse(
                vet.GetIdAs().ToString(),
                vet.Name.ToString(),
                vet.ContactPhone.ToString(),
                vet.ContactEmail.ToString())
            : null;
    }
}