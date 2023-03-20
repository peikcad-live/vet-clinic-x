using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace PeikcadLive.VetClinicX.Kernel.Domain;

public partial class PublicEmail : ValueObject
{
    private static readonly Regex Pattern = GeneratePattern();
    
    public PublicEmail(string localPart, string domainName)
    {
        LocalPart = localPart;
        DomainName = domainName;
    }
    
    public string LocalPart { get; }
    
    public string DomainName { get; }

    public static PublicEmail DeserializeFrom(string value)
    {
        if (!Pattern.IsMatch(value))
            throw new DomainException(nameof(PublicEmail), new FormatException());
        
        var parts = value.Split('@', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        return new(parts.First(), parts.Last());
    }

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out PublicEmail? email, [NotNullWhen(false)] out Exception? error)
    {
        try
        {
            email = DeserializeFrom(value);
            error = null;
            return true;
        }
        catch (Exception e)
        {
            email = null;
            error = e;
            return false;
        }
    }

    [GeneratedRegex(@".+@.+\.+", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex GeneratePattern();

    public override string ToString() => $"{LocalPart}@{DomainName}";
}