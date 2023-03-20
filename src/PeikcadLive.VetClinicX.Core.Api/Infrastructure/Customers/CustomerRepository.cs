using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly CoreContext context;

    public CustomerRepository(CoreContext context)
    {
        this.context = context;
    }

    public IUnitOfWork Uow => context;

    public async Task Create(Customer customer, CancellationToken cancellationToken = default)
        => await context.Customers.AddAsync(customer.GetStateAs<CustomerState>(), cancellationToken).ConfigureAwait(false);
}