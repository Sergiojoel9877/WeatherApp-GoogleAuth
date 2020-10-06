using System;
using Newtonsoft.Json;

namespace WeatherAppGoogleAuth.Models
{
    public class Wind
    {
        [JsonProperty("speed", Required = Required.Always)]
        public double Speed { get; set; }

        [JsonProperty("deg", Required = Required.Always)]
        public long Deg { get; set; }
    }
}
