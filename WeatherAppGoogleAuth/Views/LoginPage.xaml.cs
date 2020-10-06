using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;
using WeatherAppGoogleAuth.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherAppGoogleAuth.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = Locator.Current.GetService<LoginViewModel>();
        }
    }
}