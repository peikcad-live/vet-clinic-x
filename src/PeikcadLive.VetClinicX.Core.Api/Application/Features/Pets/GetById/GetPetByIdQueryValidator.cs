using FluentValidation;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.GetById;

public sealed class GetPetByIdQueryValidator : AbstractValidator<GetPetByIdQuery>
{
    public GetPetByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .Must(v => AnimalId.TryDeserializeFrom(v, out _, out _));
    }
}