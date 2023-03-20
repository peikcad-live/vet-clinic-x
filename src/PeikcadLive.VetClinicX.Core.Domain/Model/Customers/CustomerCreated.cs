namespace PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

public sealed class CustomerCreated : IDomainEvent
{
    public CustomerCreated(Customer customer)
    {
        Id = customer.GetIdAs().ToString();
        Name = customer.GetStateAs().Name;
        ContactPhone = customer.GetStateAs().ContactPhone;
        ContactEmail = customer.GetStateAs().ContactEmail;
    }

    public Guid EventId { get; } = Guid.NewGuid();
    
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    
    public string ContactEmail { get; set; }

    public string ContactPhone { get; set; }

    public string Name { get; set; }

    public string Id { get; set; }
}