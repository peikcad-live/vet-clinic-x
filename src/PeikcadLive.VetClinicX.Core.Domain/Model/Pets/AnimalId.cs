using System.Diagnostics.CodeAnalysis;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Pets;

public sealed class AnimalId : ValueObject, IDomainId
{
    public AnimalId(string value) : base(value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    public bool IsSameAs(IDomainId compared) => compared is AnimalId id && Equals(id);

    public static AnimalId DeserializeFrom(string value) => new(value);

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out AnimalId? id, [NotNullWhen(false)] out Exception? error)
    {
        try
        {
            id = DeserializeFrom(value);
            error = null;
            return true;
        }
        catch (Exception e)
        {
            id = null;
            error = e;
            return false;
        }
    }

    public override string ToString() => Value;
}