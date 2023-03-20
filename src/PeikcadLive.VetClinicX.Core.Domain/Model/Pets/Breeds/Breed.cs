using PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;

public sealed class Breed : DomainEntity<BreedId, IBreedState>
{
    private Breed(IBreedState state, BreedId id) : base(state, id)
    {
    }

    public string Name => GetStateAs().Name;

    public Species Species => Species.RehydrateFrom(GetStateAs().Species);

    public static Breed Of(BreedId id, string name, Species species, Func<IBreedState> createState)
    {
        var state = createState();

        state.Id = (int)id.Value;
        state.Name = name;
        state.SpeciesId = (int)species.GetIdAs().Value;
        state.Species = species.GetStateAs();

        return new(state, id);
    }

    public static Breed RehydrateFrom(IBreedState state) => new(state, new(new((uint)state.Id)));
}