namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;

public sealed class Species : DomainEntity<SpeciesId, ISpeciesState>
{
    private Species(ISpeciesState state, SpeciesId id) : base(state, id)
    {
    }

    public string Name => GetStateAs().Name;

    public Species Of(SpeciesId id, string name, Func<ISpeciesState> createState)
    {
        var state = createState();

        state.Id = (int)id.Value;
        state.Name = name;

        return new(state, id);
    }

    public static Species RehydrateFrom(ISpeciesState state) => new(state, new(new((uint)state.Id)));
}