using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherAppGoogleAuth.Services;
using WeatherAppGoogleAuth.Views;

namespace WeatherAppGoogleAuth
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            SetContainerInitializer();

            MainPage = new AppShell();
        }

        //Set the initializer and subsecuentially it starts to register every service.
        void SetContainerInitializer() => new ContainerInitializer().Initialize();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
