using PeikcadLive.VetClinicX.Core.Domain.Model.Customers;
using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;
using PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public sealed class Pet : DomainEntity<AnimalId, IPetState>, IAggregateRoot
{
    private Pet(IPetState state, AnimalId id) : base(state, id)
    {
    }
    
    public CompleteName Name => CompleteName.DeserializeFrom(GetStateAs().Name);

    public CustomerCode HumanCompanion => new(GetStateAs().HumanCompanionId);

    public LicenseNumber? Veterinarian => GetStateAs().VeterinarianId is {} id ? new(id) : null;

    public Breed Breed => Breed.RehydrateFrom(GetStateAs().Breed);

    public static Pet Of(AnimalId id, CompleteName name, CustomerCode humanCompanion, Breed breed, Func<IPetState> createState)
    {
        var state = createState();

        state.Id = id.ToString();
        state.Name = name.ToString();
        state.HumanCompanionId = humanCompanion.ToString();
        state.BreedId = (int)breed.GetIdAs().Value;
        state.Breed = breed.GetStateAs();

        var pet = new Pet(state, id);
        
        pet.Raise(new PetCreated(pet));

        return pet;
    }

    public static Pet RehydrateFrom(IPetState state) => new(state, new(state.Id));

    public void Assign(Veterinarian veterinarian)
    {
        GetStateAs().VeterinarianId = veterinarian.GetIdAs().ToString();
        
        Raise(new PetVetAssigned(this, veterinarian.GetIdAs()));
    }
}