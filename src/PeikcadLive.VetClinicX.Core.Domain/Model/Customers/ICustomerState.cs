namespace PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

public interface ICustomerState : IDomainState
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string ContactPhone { get; set; }
    
    public string ContactEmail { get; set; }
}