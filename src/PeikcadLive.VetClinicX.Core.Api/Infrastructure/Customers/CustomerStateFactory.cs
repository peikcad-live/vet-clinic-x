using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;

public sealed class CustomerStateFactory : IStateFactory<ICustomerState>
{
    public ICustomerState Create() => new CustomerState();
}