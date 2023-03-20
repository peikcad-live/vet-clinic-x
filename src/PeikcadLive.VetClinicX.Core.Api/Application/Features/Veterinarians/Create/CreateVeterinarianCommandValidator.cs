using FluentValidation;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Kernel.Domain;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.Create;

public sealed class CreateVeterinarianCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateVeterinarianCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .Must(v => CustomerCode.TryDeserializeFrom(v, out _, out _));

        RuleFor(c => c.CompleteName)
            .Must(v => CompleteName.TryDeserializeFrom(v, out _, out _));

        RuleFor(c => c.ContactPhone)
            .NotEmpty()
            .Must(v => UsPhoneNumber.TryDeserializeFrom(v, out _, out _));

        RuleFor(c => c.ContactEmail)
            .NotEmpty()
            .Must(v => CorporateEmail.TryDeserializeFrom(v, out _, out _));
    }
}