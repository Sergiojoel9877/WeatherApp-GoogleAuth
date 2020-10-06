using System;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    public class Coord
    {
        [JsonProperty("lon", Required = Required.Always)]
        public double Lon { get; set; }

        [JsonProperty("lat", Required = Required.Always)]
        public double Lat { get; set; }
    }
}
