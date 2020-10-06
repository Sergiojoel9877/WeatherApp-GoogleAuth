using WeatherAppGoogleAuth.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using AsyncAwaitBestPractices.MVVM;
using System.Threading.Tasks;
using Plugin.GoogleClient;
using WeatherAppGoogleAuth.Helpers;
using System.Diagnostics;
using Newtonsoft.Json;
using Plugin.GoogleClient.Shared;

namespace WeatherAppGoogleAuth.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        IGoogleClientManager _GoogleService = CrossGoogleClient.Current;
        ReactiveExtensionsUtils _ReactiveExtensionsUtils { get; } = new ReactiveExtensionsUtils();

        /// <summary>
        /// Creates an Async Command.
        /// </summary>
        readonly Lazy<AsyncCommand> _LoginButtonCommand;
        public Lazy<AsyncCommand> LoginButtonCommand => _LoginButtonCommand ?? (new Lazy<AsyncCommand>(()=> new AsyncCommand(async ()=>
        {
            await Task.Yield();

            try
            {
                if (!string.IsNullOrEmpty(_GoogleService.AccessToken))
                {
                    //Always require user authentication
                    _GoogleService.Logout();
                }

                //Subscribe to the Google Login IObservable method
                //_ReactiveExtensionsUtils.GoogleLoginObservable()
                //.Subscribe(async google =>
                //{
                EventHandler<GoogleClientResultEventArgs<GoogleUser>> userLoginDelegate = null;
                userLoginDelegate = async (object sender, GoogleClientResultEventArgs<GoogleUser> e) =>
                {
                    switch (e.Status)
                    {
                        case GoogleActionStatus.Completed:
                            var googleUserString = JsonConvert.SerializeObject(e.Data);
                            Debug.WriteLine($"Google Logged in succesfully: {googleUserString}");
                            await Shell.Current.GoToAsync("/WeatherPage", true);
                        break;
                        case GoogleActionStatus.Canceled:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Canceled", "Ok");
                        break;
                        case GoogleActionStatus.Error:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Error", "Ok");
                        break;
                        case GoogleActionStatus.Unauthorized:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Unauthorized", "Ok");
                        break;
                    }
                    _GoogleService.OnLogin -= userLoginDelegate;
                };

                _GoogleService.OnLogin += userLoginDelegate;

                await _GoogleService.LoginAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        })));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
