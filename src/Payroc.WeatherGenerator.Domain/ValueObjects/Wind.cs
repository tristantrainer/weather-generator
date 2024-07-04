using Payroc.WeatherGenerator.Domain.Common;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public class Wind(Speed speed, PrincipalDirection direction) : ValueObject
{
    public PrincipalDirection PrincipalDirection { get; } = direction;
    public Speed Speed { get; } = speed;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PrincipalDirection;
        yield return Speed;
    }
}
