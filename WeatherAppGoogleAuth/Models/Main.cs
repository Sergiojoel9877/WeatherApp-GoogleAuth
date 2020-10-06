using System;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    public class Main
    {
        [JsonProperty("temp", Required = Required.Always)]
        public double Temp { get; set; }

        [JsonProperty("feels_like", Required = Required.Always)]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min", Required = Required.Always)]
        public double TempMin { get; set; }

        [JsonProperty("temp_max", Required = Required.Always)]
        public double TempMax { get; set; }

        [JsonProperty("pressure", Required = Required.Always)]
        public long Pressure { get; set; }

        [JsonProperty("humidity", Required = Required.Always)]
        public long Humidity { get; set; }
    }
}
