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
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
