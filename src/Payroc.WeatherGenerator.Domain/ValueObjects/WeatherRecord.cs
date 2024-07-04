using Payroc.WeatherGenerator.Domain.Common;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public class WeatherRecord : ValueObject
{
    public required DateTime Timestamp { get; init; }
    public required WeatherInformation[] InformationByLocation { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Timestamp;

        foreach(var location in InformationByLocation) 
        {
            yield return location;
        }
    }
}
