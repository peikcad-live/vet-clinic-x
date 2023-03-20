using System.Diagnostics.CodeAnalysis;

namespace PeikcadLive.VetClinicX.Kernel.Domain;

public class UsPhoneNumber : ValueObject
{
    public UsPhoneNumber(int areaCode, int centralOfficeCode, int number)
        : base(areaCode, centralOfficeCode, number)
    {
        AreaCode = areaCode;
        CentralOfficeCode = centralOfficeCode;
        Number = number;
    }
    
    public int AreaCode { get; }
    
    public int CentralOfficeCode { get; }
    
    public int Number { get; }

    public static UsPhoneNumber DeserializeFrom(string value)
    {
        var parts = value.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        return new(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out UsPhoneNumber? phone, [NotNullWhen(false)] out Exception? error)
    {
        try
        {
            phone = DeserializeFrom(value);
            error = null;
            return true;
        }
        catch (Exception e)
        {
            phone = null;
            error = e;
            return false;
        }
    }

    public override string ToString() => $"{AreaCode} {CentralOfficeCode} {Number}";
}