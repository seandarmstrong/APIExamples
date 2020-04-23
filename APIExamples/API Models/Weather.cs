using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamples.API_Models
{
    public class Weather
    {
        //property name always has to align with the JSON property
        public WeatherData Data { get; set; }
        public WeatherTime Time { get; set; }
    }
}
