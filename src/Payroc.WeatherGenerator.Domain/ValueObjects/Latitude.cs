using Payroc.WeatherGenerator.Domain.Common;
using Payroc.WeatherGenerator.Domain.Exceptions;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public sealed class Latitude(double value) : ValueObject
{
    public const int MaxValue = 90;
    public const int MinValue = -90;

    public double Value { get; } = Validate(value);

    public static implicit operator Latitude(double value) => new(value);

    private static double Validate(double value) 
    {
        if(value < MinValue || value > MaxValue) {
            throw new LatitudeOutOfRangeException($"{value} is outside the range for latitudes ({MinValue} - {MaxValue})");
        }

        return value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
