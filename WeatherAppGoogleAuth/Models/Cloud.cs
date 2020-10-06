using System;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    public class Cloud
    {
        [JsonProperty("all", Required = Required.Always)]
        public long All { get; set; }
    }
}
