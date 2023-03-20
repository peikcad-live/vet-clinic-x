namespace PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

public sealed class Veterinarian : DomainEntity<LicenseNumber, IVeterinarianState>, IAggregateRoot
{
    private Veterinarian(IVeterinarianState state, LicenseNumber id) : base(state, id)
    {
    }
    
    public CompleteName Name => CompleteName.DeserializeFrom(GetStateAs().Name);
    
    public UsPhoneNumber ContactPhone => UsPhoneNumber.DeserializeFrom(GetStateAs().ContactPhone);
    
    public CorporateEmail ContactEmail => CorporateEmail.DeserializeFrom(GetStateAs().ContactEmail);

    public static Veterinarian Of(LicenseNumber license, CompleteName name, UsPhoneNumber contactPhone, CorporateEmail contactEmail, Func<IVeterinarianState> createState)
    {
        var state = createState();

        state.Id = license.ToString();
        state.Name = name.ToString();
        state.ContactPhone = contactPhone.ToString();
        state.ContactEmail = contactEmail.ToString();

        var veterinarian = new Veterinarian(state, license);
        
        veterinarian.Raise(new VeterinarianCreated(veterinarian));

        return veterinarian;
    }

    public static Veterinarian RehydrateFrom(IVeterinarianState state) => new(state, new(state.Id));
}