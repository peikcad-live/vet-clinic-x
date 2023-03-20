namespace PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

public interface ICustomerRepository : IRepository
{
    Task Create(Customer customer, CancellationToken cancellationToken = default);
}