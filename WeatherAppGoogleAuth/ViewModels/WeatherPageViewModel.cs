  using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AsyncAwaitBestPractices.MVVM;
using Splat;
using WeatherAppGoogleAuth.Helpers;
using WeatherAppGoogleAuth.Models;
using WeatherAppGoogleAuth.Services.Abstract;
using Xamarin.Essentials;

namespace WeatherAppGoogleAuth.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The <see cref="Models.Weather"/> object
        /// </summary>
        public Weather Weather { get; set; }

        IRestService _RestService { get; } = Locator.Current.GetService<IRestService>();

        /// <summary>
        /// Creates an Async Command.
        /// </summary>
        readonly Lazy<AsyncCommand> _GetWeatherData = null;
        public Lazy<AsyncCommand> GetWeatherData => _GetWeatherData ?? (new Lazy<AsyncCommand>(()=> new AsyncCommand(async ()=>
        {
            await Task.Yield();

            IProgressDialog progresss = UserDialogs.Instance.Loading("Loading...", null, null, true, MaskType.Black);

            try
            {
                progresss.Show();
                Location currentLocation = await GetCurrentLocation();
                await MainThread.InvokeOnMainThreadAsync(async ()=>
                {
                    Weather = await _RestService.GetWeatherByCoordinates(currentLocation.Latitude.ToString(), currentLocation.Longitude.ToString(), ApiDataAccess.OpenWeatherKey);
                });
                progresss.Hide();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await App.Current.MainPage.DisplayAlert("Please check you GPS and try again", "Canceled", "Ok");
            }
            finally
            {
                progresss.Dispose();
            }
        })));

        /// <summary>
        /// Gets the current location
        /// </summary>
        /// <returns>The real-time <see cref="Location" of the user/></returns>
        async Task<Location> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Debug.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    return location;
                }
                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                throw new FeatureNotSupportedException();
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                throw new FeatureNotEnabledException();
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                throw new PermissionException("Please give permissions to the app to be able to get your location");
            }
            catch (Exception ex)
            {
                // Unable to get location
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
