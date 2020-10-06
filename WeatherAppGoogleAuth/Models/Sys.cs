using System;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    public class Sys
    {
        [JsonProperty("type", Required = Required.Always)]
        public long Type { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        //[JsonProperty("message", Required = Required.Always)]
        //public double Message { get; set; }

        [JsonProperty("country", Required = Required.Always)]
        public string Country { get; set; }

        [JsonProperty("sunrise", Required = Required.Always)]
        public long Sunrise { get; set; }

        [JsonProperty("sunset", Required = Required.Always)]
        public long Sunset { get; set; }
    }
}
