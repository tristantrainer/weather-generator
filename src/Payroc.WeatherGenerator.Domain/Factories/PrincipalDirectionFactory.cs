using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories;

public class PrincipalDirectionFactory
{
    private static PrincipalDirection[] _options = [
        PrincipalDirection.North,
        PrincipalDirection.South,
        PrincipalDirection.East,
        PrincipalDirection.West,
        PrincipalDirection.NorthEast,
        PrincipalDirection.NorthWest,
        PrincipalDirection.SouthEast,
        PrincipalDirection.SouthWest,
    ];

    public static PrincipalDirection CreateRandom() 
    {
        return new PrincipalDirection(_options.Sample().Code);
    }
}
