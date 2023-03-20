using FluentValidation;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Veterinarians.GetById;

public sealed class GetVeterinarianByIdQueryValidator : AbstractValidator<GetVeterinarianByIdQuery>
{
    public GetVeterinarianByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .Must(v => LicenseNumber.TryDeserializeFrom(v, out _, out _));
    }
}