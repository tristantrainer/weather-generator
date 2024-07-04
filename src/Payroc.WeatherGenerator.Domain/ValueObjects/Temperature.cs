using Payroc.WeatherGenerator.Domain.Common;
using Payroc.WeatherGenerator.Domain.Enums;
using Payroc.WeatherGenerator.Domain.Exceptions;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public class Temperature(double value, UnitOfTemperature unit) : ValueObject
{
    private const int KelvinAbsoluteZero = 0;

    private readonly double _kelvin = ConvertToKelvin(value, unit);

    public UnitOfTemperature UnitOfMeasurement { get; } = unit;

    public double Value { get; } = ValidateValue(value, unit);

    public static double MinValue(UnitOfTemperature unit) 
    {
        return unit switch {
            UnitOfTemperature.Kelvin => KelvinAbsoluteZero,
            UnitOfTemperature.Celsius => KelvinAbsoluteZero - 273.15,
            UnitOfTemperature.Fahrenheit => ((KelvinAbsoluteZero - 273.15) * 9/5) + 32,
            _ => throw new UnitOfTemperatureNotSupportedException()
        };
    }

    public static double ReasonableMaxValue(UnitOfTemperature unit) 
    {
        return unit switch {
            UnitOfTemperature.Kelvin => 400,
            UnitOfTemperature.Celsius => 200,
            UnitOfTemperature.Fahrenheit => 200,
            _ => throw new UnitOfTemperatureNotSupportedException()
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _kelvin;
    }

    private static double ValidateValue(double value, UnitOfTemperature unit) 
    {
        if(ConvertToKelvin(value, unit) < KelvinAbsoluteZero) {
            throw new TemperatureOutOfRangeException($"Value cannot be less than absolute zero ({KelvinAbsoluteZero}K), found {value} in {unit}");
        }

        return value;
    }

    private static double ConvertToKelvin(double value, UnitOfTemperature unit)
    {
        return unit switch {
            UnitOfTemperature.Kelvin => value,
            UnitOfTemperature.Celsius => value + 273.15,
            UnitOfTemperature.Fahrenheit => ((value - 32) * 5/9) + 273.15,
            _ => throw new UnitOfTemperatureNotSupportedException()
        };
    }
}