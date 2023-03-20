using System.Diagnostics.CodeAnalysis;

namespace PeikcadLive.VetClinicX.Core.Domain.Model.Customers;

public sealed class CustomerCode : ValueObject, IDomainId
{
    public CustomerCode(string value) : base(value)
    {
        Value = value;
    }

    public string Value { get; }

    public static CustomerCode DeserializeFrom(string value) => new(value);

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out CustomerCode? code, [NotNullWhen(false)] out Exception? error)
    {
        try
        {
            code = DeserializeFrom(value);
            error = null;
            return true;
        }
        catch (Exception e)
        {
            code = null;
            error = e;
            return false;
        }
    }

    public bool IsSameAs(IDomainId compared) => compared is CustomerCode code && Equals(code);

    public override string ToString() => Value;
}