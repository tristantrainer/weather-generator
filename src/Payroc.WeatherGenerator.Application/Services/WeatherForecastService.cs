using Payroc.WeatherGenerator.Application.Options;
using Payroc.WeatherGenerator.Core.Extensions;
using Payroc.WeatherGenerator.Core.Models;
using Payroc.WeatherGenerator.Domain.Factories;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Application.Services
{
    public class WeatherForecastService
    {
        public static WeatherRecord[] GenerateForecastData(WeatherForecastOptions forecastOptions, WeatherInformationOptions informationOptions) 
        {
            var recordTimestamps = CreateDateTimeSeries(forecastOptions);

            return recordTimestamps
                .Select((timestamp) => new WeatherRecord {
                    Timestamp = timestamp,
                    InformationByLocation = CreateRecordWeatherInformation(forecastOptions.InformationRangePerRecord, informationOptions)
                })
                .ToArray();
        } 

        private static DateTime[] CreateDateTimeSeries(WeatherForecastOptions options)
        {
            return Enumerable
                .Range(0, options.NumberOfRecords)
                .Select((offset) => options.Start.Add(options.RecordInterval * offset))
                .ToArray();
        }

        private static WeatherInformation[] CreateRecordWeatherInformation(Range<int> countRange, WeatherInformationOptions options) {
            var random = new Random();
            
            return Enumerable
                .Range(0, random.Next(countRange.Min, countRange.Max))
                .Select((index) => CreateWeatherInformationData(options)) 
                .ToArray();
        }

        private static WeatherInformation CreateWeatherInformationData(WeatherInformationOptions options) 
        {
            var temperatureUnit = options.UnitOfTemperatureOptions.Sample();
            var speedUnit = options.UnitOfSpeedOptions.Sample();

            return new WeatherInformation 
            {
                Latitude = LatitudeFactory.CreateRandom(options.LatitudeRange),
                Longitude = LongitudeFactory.CreateRandom(options.LongitudeRange),
                Temperature = TemperatureFactory.CreateRandom(temperatureUnit),
                Wind = WindFactory.Create(SpeedFactory.CreateRandom(speedUnit), PrincipalDirectionFactory.CreateRandom()),
                PrecipitationProbability = ProbabilityFactory.CreateRandom()
            };
        }
    }
}

