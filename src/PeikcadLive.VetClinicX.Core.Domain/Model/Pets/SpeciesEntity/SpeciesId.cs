namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.SpeciesEntity;

public sealed class SpeciesId : ValueObject, IDomainId
{
    public SpeciesId(PositiveNaturalNumber value) : base(value.Value)
    {
        Value = value.Value;
    }

    public uint Value { get; }
    
    public bool IsSameAs(IDomainId compared) => compared is SpeciesId id && Equals(id);

    public override string ToString() => Value.ToString();
}