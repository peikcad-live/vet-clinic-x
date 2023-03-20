namespace PeikcadLive.VetClinicX.Kernel.Domain;

public class PersonalTreatment : ValueObject
{
    public string Value { get; }

    public PersonalTreatment(string value) : base(value)
    {
        Value = value;
    }

    public static readonly PersonalTreatment Empty = new(string.Empty);

    public static PersonalTreatment OfMr() => new("Mr.");

    public static PersonalTreatment OfMrs() => new("Mrs.");

    public static PersonalTreatment OfMs() => new("Ms.");

    public override string ToString() => Value;
}