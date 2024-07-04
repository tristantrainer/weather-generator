using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Core.Models;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories;

public class LatitudeFactory
{
    public static Latitude CreateRandom(Range<double> range) 
    {
        var random = new Random();
        return new Latitude(random.NextDouble(range.Min, range.Max));
    }
}
