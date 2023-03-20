using FluentValidation;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets;
using PeikcadLive.VetClinicX.Kernel.Domain;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Pets.Create;

public sealed class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
{
    public CreatePetCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .Must(v => AnimalId.TryDeserializeFrom(v, out _, out _));

        RuleFor(c => c.CompleteName)
            .NotEmpty()
            .Must(v => CompleteName.TryDeserializeFrom(v, out _, out _));

        RuleFor(c => c.CompanionId)
            .NotEmpty()
            .Must(v => CustomerCode.TryDeserializeFrom(v, out _, out _));

        RuleFor((c => c.BreedId))
            .GreaterThan(0);
    }
}