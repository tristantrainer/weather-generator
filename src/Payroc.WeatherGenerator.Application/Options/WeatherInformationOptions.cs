using Payroc.WeatherGenerator.Core.Models;
using Payroc.WeatherGenerator.Domain.Enums;

namespace Payroc.WeatherGenerator.Application.Options;

public class WeatherInformationOptions 
{
    public required Range<double> LatitudeRange { get; set; }
    public required Range<double> LongitudeRange { get; set; } 
    public required Range<double> ProbabilityRange { get; set; } 
    public required UnitOfSpeed[] UnitOfSpeedOptions { get; set; }
    public required UnitOfTemperature[] UnitOfTemperatureOptions { get; set; } 

    public WeatherInformationOptions Clone() 
    {
        return new() 
        {
            LatitudeRange = LatitudeRange,
            LongitudeRange = LongitudeRange,
            ProbabilityRange  = ProbabilityRange,
            UnitOfSpeedOptions = UnitOfSpeedOptions,
            UnitOfTemperatureOptions = UnitOfTemperatureOptions
        };
    }
}