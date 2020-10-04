using System.ComponentModel;
using Xamarin.Forms;
using WeatherAppGoogleAuth.ViewModels;

namespace WeatherAppGoogleAuth.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}