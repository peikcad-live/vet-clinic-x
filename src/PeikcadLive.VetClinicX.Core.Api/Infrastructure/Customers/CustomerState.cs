using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure.Customers;

public sealed class CustomerState : ICustomerState
{
    internal CustomerState()
    {
    }
    
    public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();

    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string ContactPhone { get; set; } = string.Empty;

    public string ContactEmail { get; set; } = string.Empty;
}