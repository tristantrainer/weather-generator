// See https://aka.ms/new-console-template for more information
using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Application.Options;
using Payroc.WeatherGenerator.Domain.Enums;
using Payroc.WeatherGenerator.Domain.ValueObjects;
using Payroc.WeatherGenerator.Core.Models;
using Payroc.WeatherGenerator.Application.Services;
using Payroc.WeatherGenerator.Application.IO;

Console.WriteLine("Hello, World!");

var outputFilePath = @"** Choose a suitable file path **.WIS";

var informationOptions = new WeatherInformationOptions() 
{
    LatitudeRange = new(Latitude.MinValue, Latitude.MaxValue),
    LongitudeRange = new(Longitude.MinValue, Longitude.MaxValue),
    ProbabilityRange  = new(Probability.MinValue, Probability.MaxValue),
    UnitOfSpeedOptions = [UnitOfSpeed.KilometersPerHour],
    UnitOfTemperatureOptions = [UnitOfTemperature.Celsius, UnitOfTemperature.Fahrenheit]
};

var forecastOptions = new WeatherForecastOptions() {
    Start = DateTime.UtcNow.AsOfPreviousHour(),
    TotalDays = 7,
    RecordInterval = TimeSpan.FromHours(1),
    InformationRangePerRecord = new Range<int>(1, 10),
};

var weatherForecast = WeatherForecastService.GenerateForecastData(forecastOptions, informationOptions);

FileWriter.WriteTabDelimitedWISFile(outputFilePath, weatherForecast);
