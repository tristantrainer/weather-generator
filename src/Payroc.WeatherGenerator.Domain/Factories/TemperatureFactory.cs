using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Domain.Enums;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories;

public class TemperatureFactory
{
    public static Temperature CreateRandom(UnitOfTemperature unit) 
    {
        var value = new Random().NextDouble(Temperature.MinValue(unit), Temperature.ReasonableMaxValue(unit));
        return new Temperature(value, unit);
    }
}
