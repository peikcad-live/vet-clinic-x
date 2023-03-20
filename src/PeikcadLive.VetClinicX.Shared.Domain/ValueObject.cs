namespace PeikcadLive.VetClinicX.Shared.Domain;

public abstract class ValueObject
{
    private readonly object[] keys;

    protected ValueObject(params object[] keys)
    {
        this.keys = keys;
    }

    public override int GetHashCode() => HashCode.Combine(keys);

    public override bool Equals(object? obj) => ReferenceEquals(obj, this) || obj is ValueObject compared && compared.keys.SequenceEqual(keys);

    public static bool operator ==(ValueObject? a, ValueObject? b) => ReferenceEquals(a, b) || a is not null && b is not null && a.Equals(b);

    public static bool operator !=(ValueObject? a, ValueObject? b) => !(a == b);
}