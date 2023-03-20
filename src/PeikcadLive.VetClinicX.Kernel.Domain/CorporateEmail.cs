using System.Diagnostics.CodeAnalysis;

namespace PeikcadLive.VetClinicX.Kernel.Domain;

public class CorporateEmail : PublicEmail
{
    public const string CorporateDomainName = "vet-clinic-x.com";
    
    public CorporateEmail(string localPart) : base(localPart, CorporateDomainName)
    {
    }

    public new static CorporateEmail DeserializeFrom(string value)
    {
        if (!value.EndsWith(CorporateDomainName))
            throw new DomainException(nameof(CorporateEmail), new FormatException());

        return new(PublicEmail.DeserializeFrom(value).LocalPart);
    }

    public static bool TryDeserializeFrom(string value, [NotNullWhen(true)] out CorporateEmail? email, [NotNullWhen(false)] out Exception? error)
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
}