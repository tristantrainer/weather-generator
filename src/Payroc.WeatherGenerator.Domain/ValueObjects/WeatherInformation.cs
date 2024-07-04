using Payroc.WeatherGenerator.Domain.Common;

namespace Payroc.WeatherGenerator.Domain.ValueObjects;

public class WeatherInformation : ValueObject
{
    public required Latitude Latitude { get; init; }
    public required Longitude Longitude { get; init; }
    public required Probability PrecipitationProbability { get; init; }
    public required Temperature Temperature { get; init; }
    public required Wind Wind { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
        yield return PrecipitationProbability;
        yield return Temperature;
        yield return Wind;
    }
}
