using Payroc.WeatherGenerator.Domain.Common;
using Payroc.WeatherGenerator.Domain.Exceptions;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public sealed class Longitude(double value) : ValueObject
{
    public const int MaxValue = 180;
    public const int MinValue = -180;

    public double Value { get; } = Validate(value);

    public static implicit operator Longitude(double value) => new(value);

    private static double Validate(double value) 
    {
        if(value < MinValue || value > MaxValue) {
            throw new LongitudeOutOfRangeException($"{value} is outside the range of longitudes ({MinValue} - {MaxValue})");
        }

        return value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
