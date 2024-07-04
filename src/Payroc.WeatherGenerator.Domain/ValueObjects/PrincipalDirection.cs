using Payroc.WeatherGenerator.Domain.Common;
using Payroc.WeatherGenerator.Domain.Exceptions;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public sealed class PrincipalDirection(string code) : ValueObject
{
    public static PrincipalDirection North => new("N");
    public static PrincipalDirection NorthEast => new("NE");
    public static PrincipalDirection East => new("E");
    public static PrincipalDirection SouthEast => new("SE");
    public static PrincipalDirection South => new("S");
    public static PrincipalDirection SouthWest => new("SW");
    public static PrincipalDirection West => new("W");
    public static PrincipalDirection NorthWest => new("NW");

    public string Code { get; } = ValidateCode(code);

    private static string ValidateCode(string code) 
    {
        if(!ValidDirectionCodes.Any((validCode) => validCode == code)) {
            throw new InvalidPrincipleDirectionException();
        }

        return code;
    }

    private static IEnumerable<string> ValidDirectionCodes 
    {
        get {
            yield return "N";
            yield return "S";
            yield return "E";
            yield return "W";
            yield return "NE";
            yield return "NW";
            yield return "SE";
            yield return "SW";
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return code;
    }
}
