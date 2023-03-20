using FluentValidation;
using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers.GetById;

public sealed class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .NotEmpty()
            .Must(v => CustomerCode.TryDeserializeFrom(v, out _, out _));
    }
}