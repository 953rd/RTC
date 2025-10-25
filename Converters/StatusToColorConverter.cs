using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace RTC.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public static StatusToColorConverter Instance { get; } = new StatusToColorConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                return status.ToLower() switch
                {
                    "завершен" => "#27ae60",
                    "в работе" => "#3498db",
                    "отстает" => "#e74c3c",
                    "на паузе" => "#f39c12",
                    "планирование" => "#95a5a6",
                    _ => "#7f8c8d"
                };
            }
            return "#7f8c8d";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}