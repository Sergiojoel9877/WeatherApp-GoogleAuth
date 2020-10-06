using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    /// <summary>
    /// Represents the Weather as a whole inside the application
    /// </summary>
    public class Weather
    {
        [JsonProperty("coord", Required = Required.Always)]
        public Coord Coord { get; set; }

        [JsonProperty("weather", Required = Required.Always)]
        public List<WeatherElement> WeatherWeather { get; set; }

        [JsonProperty("base", Required = Required.Always)]
        public string Base { get; set; }

        [JsonProperty("main", Required = Required.Always)]
        public Main Main { get; set; }

        [JsonProperty("visibility", Required = Required.Always)]
        public long Visibility { get; set; }

        [JsonProperty("wind", Required = Required.Always)]
        public Wind Wind { get; set; }

        [JsonProperty("clouds", Required = Required.Always)]
        public Cloud Clouds { get; set; }

        [JsonProperty("dt", Required = Required.Always)]
        public long Dt { get; set; }

        [JsonProperty("sys", Required = Required.Always)]
        public Sys Sys { get; set; }

        [JsonProperty("timezone", Required = Required.Always)]
        public long Timezone { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("cod", Required = Required.Always)]
        public long Cod { get; set; }
    }
}
