using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Domain.Enums;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories;

public class SpeedFactory
{
    public static Speed CreateRandom(UnitOfSpeed unit) 
    {
        var value = new Random().NextDouble(Speed.MinValue, Speed.MaxValue(unit));
        return new Speed(value, unit);
    }
}