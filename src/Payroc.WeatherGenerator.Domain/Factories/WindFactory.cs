using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payroc.WeatherGenerator.Domain.ValueObjects;

namespace Payroc.WeatherGenerator.Domain.Factories;

public class WindFactory
{
    public static Wind Create(Speed speed, PrincipalDirection direction) 
    {
        return new Wind(speed, direction);
    }
}