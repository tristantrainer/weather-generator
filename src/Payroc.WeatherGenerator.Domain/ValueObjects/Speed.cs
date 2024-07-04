using Payroc.WeatherGenerator.Domain.Common;
using Payroc.WeatherGenerator.Domain.Enums;
using Payroc.WeatherGenerator.Domain.Exceptions;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public sealed class Speed(double value, UnitOfSpeed unit) : ValueObject
{
    private const int SpeedOfLightInMetersPerSecond = 299792458;
    private const int ReasonableMaxSpeedInMetersPerSecond = 35;
    private readonly double _normalizedValue = ConvertToMetersPerSecond(value, unit);

    public const int MinValue = 0;

    public double Value { get; } = ValidateValue(value, unit);
    public UnitOfSpeed UnitOfMeasurement { get; } = unit;

    public static double MaxValue(UnitOfSpeed unit) 
    {
        return unit switch {
            UnitOfSpeed.MetersPerSecond => ReasonableMaxSpeedInMetersPerSecond,
            UnitOfSpeed.KilometersPerHour => ReasonableMaxSpeedInMetersPerSecond * 3.6,
            _ => throw new UnitOfSpeedNotSupportedException()
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _normalizedValue;
    }

    private static double ValidateValue(double value, UnitOfSpeed unit) 
    {
        if(value < MinValue || value > MaxValue(unit)) 
        {
            throw new SpeedOutOfRangeException($"Speed values cannot be less than zero or greater than the speed of light ({MaxValue(unit)} {unit}) found {value} {unit}");
        }

        return value;
    }

    private static double ConvertToMetersPerSecond(double value, UnitOfSpeed unit)
    {
        return unit switch {
            UnitOfSpeed.MetersPerSecond => value,
            UnitOfSpeed.KilometersPerHour => value / 3.6,
            _ => throw new UnitOfSpeedNotSupportedException()
        };
    }
}
