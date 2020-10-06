using System;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    public class WeatherElement
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("main", Required = Required.Always)]
        public string Main { get; set; }

        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("icon", Required = Required.Always)]
        public string Icon { get; set; }
    }
}
