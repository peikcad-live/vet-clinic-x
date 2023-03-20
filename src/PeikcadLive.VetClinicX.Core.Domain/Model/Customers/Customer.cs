namespace PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

public sealed class Customer : DomainEntity<CustomerCode, ICustomerState>, IAggregateRoot
{
    private Customer(ICustomerState state, CustomerCode id) : base(state, id)
    {
    }
    
    public CompleteName Name => CompleteName.DeserializeFrom(GetStateAs().Name);
    
    public UsPhoneNumber ContactPhone => UsPhoneNumber.DeserializeFrom(GetStateAs().ContactPhone);
    
    public PublicEmail ContactEmail => PublicEmail.DeserializeFrom(GetStateAs().ContactEmail);

    public static Customer Of(CustomerCode id, CompleteName name, UsPhoneNumber contactPhone, PublicEmail contactEmail, Func<ICustomerState> createState)
    {
        var state = createState();

        state.Id = id.ToString();
        state.Name = name.ToString();
        state.ContactPhone = contactPhone.ToString();
        state.ContactEmail = contactEmail.ToString();

        var customer = new Customer(state, id);
        
        customer.Raise(new CustomerCreated(customer));

        return customer;
    }

    public static Customer RehydrateFrom(ICustomerState state) => new(state, new(state.Id));
}