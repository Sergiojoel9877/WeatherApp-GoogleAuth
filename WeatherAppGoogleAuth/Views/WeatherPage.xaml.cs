using System;
using System.Collections.Generic;
using Sharpnado.Tasks;
using Splat;
using WeatherAppGoogleAuth.ViewModels;
using Xamarin.Forms;

namespace WeatherAppGoogleAuth.Views
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = Locator.Current.GetService<WeatherPageViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TaskMonitor.Create(((WeatherPageViewModel)BindingContext).GetWeatherData.Value.ExecuteAsync());
        }
    }
}
