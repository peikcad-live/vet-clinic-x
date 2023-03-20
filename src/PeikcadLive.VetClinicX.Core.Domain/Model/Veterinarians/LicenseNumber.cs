using System.Diagnostics.CodeAnalysis;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Veterinarians;

public sealed class LicenseNumber : ValueObject, IDomainId
{
    public static readonly LicenseNumber Empty = new(string.Empty);
    
    public LicenseNumber(string value) : base(value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static LicenseNumber DeserializeFrom(string value) => new(value);

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out LicenseNumber? number, [NotNullWhen(false)] out Exception? error)
    {
        try
        {
            number = DeserializeFrom(value);
            error = null;
            return true;
        }
        catch (Exception e)
        {
            number = null;
            error = e;
            return false;
        }
    }

    public bool IsSameAs(IDomainId compared) => compared is LicenseNumber number && Equals(number);

    public override string ToString() => Value;
}