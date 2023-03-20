using System.Diagnostics.CodeAnalysis;

namespace PeikcadLive.VetClinicX.Kernel.Domain;

public class CompleteName : ValueObject
{
    public CompleteName(string name, string surname, PersonalTreatment? treatment = default) : base(name, surname, treatment ?? PersonalTreatment.Empty)
    {
        Name = name;
        Surname = surname;
        Treatment = treatment;
    }
    
    public string Name { get; }
    
    public string Surname { get; }
    
    public PersonalTreatment? Treatment { get; }

    public static CompleteName DeserializeFrom(string value)
    {
        var surnamePlus = value.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var namePlus = surnamePlus.Last().Split('/', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        return new(namePlus.First(), surnamePlus.First(), new PersonalTreatment(namePlus.Last()));
    }

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out CompleteName? name, [NotNullWhen(false)] out Exception? error)
    {
        try
        {
            name = DeserializeFrom(value);
            error = null;
            return true;
        }
        catch (Exception e)
        {
            name = null;
            error = e;
            return false;
        }
    }

    public override string ToString() => $"{Surname}, {Name} / {Treatment}";
}