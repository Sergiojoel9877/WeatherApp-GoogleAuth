using System;
using System.Threading.Tasks;
using Refit;
using WeatherAppGoogleAuth.Helpers;
using WeatherAppGoogleAuth.Models;

namespace WeatherAppGoogleAuth.Services.Abstract
{
    public interface IRestService
    {
        /// <summary>
        /// Gets the Weather data
        /// </summary>
        /// <param name="city">The city to search for</param>
        /// <param name="AppId">The APP Id secret code</param>
        /// <param name="unitOfMeasurement">The unit of measurement</param>
        /// <returns></returns>
        [Get("/weather?q={city}&units={unitOfMeasurement}&APPID={AppId}")]
        Task<Weather> GetWeatherByCountry(string city, string AppId, string unitOfMeasurement = "metric");

        /// <summary>
        /// Gets the Weather data by geographic coordinates
        /// </summary>
        /// <param name="lat">The current latitude</param>
        /// <param name="lon">The current longitude</param>
        /// <param name="AppId">The APP Id secret code</param>
        /// <returns></returns>
        [Get("/weather?lat={lat}&lon={lon}&APPID={AppId}")]
        Task<Weather> GetWeatherByCoordinates(string lat, string lon, string AppId);
    }
}
