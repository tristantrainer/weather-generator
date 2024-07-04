using Payroc.WeatherGenerator.Domain.Enums;
using Payroc.WeatherGenerator.Domain.Exceptions;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Application.IO;

public class FileWriter
{
    private const string TabDelimiter = "\t";

    public static void WriteTabDelimitedWISFile(string outputFilePath, WeatherRecord[] records) 
    {
        using StreamWriter writer = new(outputFilePath);

        foreach(var record in records) 
        {
            writer.WriteLine(record.Timestamp.ToString("yyyy-MM-dd HH:mm'UTC'"));

            foreach(var row in record.InformationByLocation) 
            {
                string[] data = [
                    String.Format("{0:F6}", row.Longitude.Value), 
                    String.Format("{0:F6}", row.Latitude.Value), 
                    String.Format("{0:F1}", row.Temperature.Value),
                    GetLabel(row.Temperature.UnitOfMeasurement),
                    String.Format("{0:F1}", row.Wind.Speed.Value),
                    GetLabel(row.Wind.Speed.UnitOfMeasurement),
                    row.Wind.PrincipalDirection.Code,
                    String.Format("{0:F0}", row.PrecipitationProbability.Value),
                ];

                writer.WriteLine(string.Join(TabDelimiter, data));
            }   
        }
    }

    private static string GetLabel(UnitOfTemperature unit) 
    {
        return unit switch {
            UnitOfTemperature.Celsius => "C",
            UnitOfTemperature.Fahrenheit => "F",
            UnitOfTemperature.Kelvin => "K",
            _ => throw new UnitOfTemperatureNotSupportedException()
        };
    }

    private static string GetLabel(UnitOfSpeed unit) 
    {
        return unit switch {
            UnitOfSpeed.MetersPerSecond => "m/s",
            UnitOfSpeed.KilometersPerHour => "km/h",
            _ => throw new UnitOfSpeedNotSupportedException()
        };
    }
}
