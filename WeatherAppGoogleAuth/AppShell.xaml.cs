using System;
using System.Collections.Generic;
using WeatherAppGoogleAuth.ViewModels;
using WeatherAppGoogleAuth.Views;
using Xamarin.Forms;

namespace WeatherAppGoogleAuth
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        /// <summary>
        /// Register the given routes to the Shell routing manager
        /// </summary>
        void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(WeatherPage), typeof(WeatherPage));
        }
    }
}
