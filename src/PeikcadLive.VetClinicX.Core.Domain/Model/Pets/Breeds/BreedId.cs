namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets.Breeds;

public sealed class BreedId : ValueObject, IDomainId
{
    public BreedId(PositiveNaturalNumber value) : base(value.Value)
    {
        Value = value.Value;
    }
    
    public uint Value { get; }
    
    public bool IsSameAs(IDomainId compared) => compared is BreedId id && Equals(id);
}