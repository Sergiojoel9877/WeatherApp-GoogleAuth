using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherAppGoogleAuth.Helpers.Converters
{
    /// <summary>
    /// Translates from <see cref="long"/> to <see cref="DateTime"/>
    /// </summary>
    public class LongToDateTimeConverter : IValueConverter
    {
        DateTime _time = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long dateTime = (long)value;
            return $"{_time.AddSeconds(dateTime).ToString()} UTC";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
