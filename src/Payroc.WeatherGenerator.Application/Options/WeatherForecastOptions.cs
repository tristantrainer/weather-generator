using Payroc.WeatherGenerator.Core.Models;

namespace Payroc.WeatherGenerator.Application.Options;

public class WeatherForecastOptions 
{
    public required DateTime Start { get; init; }
    public required int TotalDays { get; init; }
    public required TimeSpan RecordInterval { get; init; }
    public required Range<int> InformationRangePerRecord { get; init; }

    public int NumberOfRecords => (int)Math.Floor(TimeSpan.FromDays(TotalDays).Divide(RecordInterval));
}