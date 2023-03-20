namespace PeikcadLive.VetClinicX.Kernel.Domain;

public class PositiveNaturalNumber : ValueObject
{
    public PositiveNaturalNumber(uint value) : base(value)
    {
        if (value == 0)
            throw new ArgumentNullException(nameof(value));

        Value = value;
    }

    public uint Value { get; set; }

    public override string ToString() => Value.ToString();
}