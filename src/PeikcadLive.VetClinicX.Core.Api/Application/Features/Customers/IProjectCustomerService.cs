using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

namespace PeikcadLive.VetClinicX.Core.Api.Application.Features.Customers;

public interface IProjectCustomerService
{
    Task<Customer?> ProjectBy(CustomerCode id);
}