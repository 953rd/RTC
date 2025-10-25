using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace RTC.Converters
{
    public class IsNotNullOrEmptyConverter : IValueConverter
    {
        public static IsNotNullOrEmptyConverter Instance { get; } = new IsNotNullOrEmptyConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}