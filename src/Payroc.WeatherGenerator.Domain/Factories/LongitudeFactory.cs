using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Core.Models;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories;

public class LongitudeFactory
{
    public static Longitude CreateRandom(Range<double> range) 
    {
        var random = new Random();
        return new Longitude(random.NextDouble(range.Min, range.Max));
    }
}
